    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.Security;
    using System.Security.Authentication;
    using System.Text;
    using System.Threading;
    using System.Web;
    
    using Example.Lib.Common;
    using Example.Lib.Models;
    
    namespace Example.Lib.Net
    {
        internal enum RequestType
        {
            None = 0,
            GET = 1,
            POST = 2,
            OPTIONS = 3
        }
    
        internal class TcpWebConnection : IDisposable
        {
            #region private members
    
            private bool m_IsDisposed = false;
            private bool m_IsSSL = false;
            private bool m_HasHeaders = false;
            private bool m_FileCreated = false;
            private bool m_IsFileUpload = false;
            private RequestType m_RequestType = RequestType.None;
            private string m_ReadData = string.Empty;
            private string m_Request = string.Empty;
            private string m_RemoteIP = string.Empty;
            private string m_AbsoluteURI = string.Empty;
            private string m_ContentType = string.Empty;
            private string m_TempFilename = string.Empty;
            private byte[] m_EndBoundaryBytes = null;
            private byte[] m_StartBoundaryBytes = null;
            private int m_ContentLength = 0;
            private long m_StartBoundaryIndex = -1;
            private long m_EndBoundaryIndex = -1;
            private long m_BytesRead = 0;
            private NameValueCollection m_QueryString = null;
            private string[] m_Segments = new string[1];
            private string m_HttpVersion = "HTTP/1.1";
            private byte[] m_PostData = null;
            private byte[] m_Buffer = new byte[65535];
            private ReadWriteBuffer m_TempBuffer;
            private FileStream m_FileStream = null;
            private MemoryStream m_FullBuffer = new MemoryStream();
            private TcpClient m_Client = null;
            private System.IO.Stream m_NetworkStream = null;
            private TcpWebServer m_Parent = null;
            private Thread m_Thread_Read = null;
            private Timer m_Timer_Check = null;
            private DateTime m_LastRead = DateTime.Now;
            private AutoResetEvent m_WaitHandle_Write;
    
            #endregion private members
    
            #region constructors
    
            internal TcpWebConnection(TcpClient client, TcpWebServer parent, bool ssl)
            {
                m_WaitHandle_Write = new AutoResetEvent(false);
                m_TempBuffer = new ReadWriteBuffer(65535);
                m_IsSSL = ssl;
                m_Segments[0] = string.Empty;
                m_Client = client;
                m_Parent = parent;
                m_RemoteIP = ((IPEndPoint)m_Client.Client.RemoteEndPoint).Address.ToString();
    
                if (ssl)
                {
                    m_NetworkStream = new SslStream(m_Client.GetStream(), false);
                }
                else
                {
                    m_NetworkStream = m_Client.GetStream();
                }
    
                m_NetworkStream.ReadTimeout = 2000;
    
                m_Timer_Check = new Timer(Timer_Check_Callback, this, 2000, 2000);
    
                // start threads
                m_Thread_Read = new Thread(DoRead);
                m_Thread_Read.IsBackground = true;
                m_Thread_Read.Start();
            }
    
            #endregion constructors
    
            #region destructors
    
            ~TcpWebConnection()
            {
                try
                {
                    if (m_Timer_Check != null) m_Timer_Check.Dispose();
                    m_Timer_Check = null;
                }
                catch { } // if the timer was 
            }
    
            #endregion destructors
    
            #region internal properties
    
            internal bool IsLargeFileUpload { get; set; } = false;
    
            internal string TempFilename
            {
                get { return m_TempFilename; }
                set { m_TempFilename = value; }
            }
    
            /// <summary>
            /// Remote IP
            /// </summary>
            internal string RemoteIP
            {
                get { return m_RemoteIP; }
            }
    
            internal string AbsoluteURI
            {
                get { return m_AbsoluteURI; }
            }
    
            internal string ContentType
            {
                get { return m_ContentType; }
            }
    
            internal string[] Segments
            {
                get { return m_Segments; }
            }
    
            internal NameValueCollection QueryString
            {
                get { return m_QueryString; }
            }
    
            internal Stream NetworkStream
            {
                get { return m_NetworkStream; }
            }
    
            internal int ContentLength
            {
                get { return m_ContentLength; }
            }
    
            #endregion internal properties
    
            #region private methods
    
            private void Timer_Check_Callback(object state)
            {
                if ((DateTime.Now - m_LastRead).TotalSeconds > 15)
                {
                    try
                    {
                        Program.BlacklistIP(m_RemoteIP, "TcpWebConnection - Timer", "Connection Timed Out");
                        ProcessRequest(m_ReadData);
                        Dispose();
                    }
                    catch (Exception e) { }
                }
            }
    
            private void DoRead()
            {
                if (m_IsSSL)
                {
                    try
                    {
                        ((SslStream)m_NetworkStream).AuthenticateAsServer(m_Parent.ServerCertificate, false, SslProtocols.Tls, false);
                        ((SslStream)m_NetworkStream).BeginRead(m_Buffer, 0, m_Buffer.Length, new AsyncCallback(SslRead), m_NetworkStream);
                        m_NetworkStream.ReadTimeout = 5000;
                        m_NetworkStream.WriteTimeout = 5000;
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine("SSL Auth Error: " + e.Message);
                    }
                }
                else
                {
                    NormalRead();
                }
            }
    
            private void UpdatePostData()
            {
                m_FullBuffer.Position = 0;
                byte[] fullBuffer = Common.Conversion.MemoryStreamToByteArray(m_FullBuffer);
                m_FullBuffer.Dispose();
    
                if (m_StartBoundaryIndex > -1 && m_EndBoundaryIndex > -1)
                {
                    m_PostData = new byte[m_EndBoundaryIndex - m_StartBoundaryIndex];
                    Array.Copy(fullBuffer, m_StartBoundaryIndex, m_PostData, 0, m_EndBoundaryIndex - m_StartBoundaryIndex);
                }
            }
    
            internal void SaveFile(string filepath)
            {
                try
                {
                    UpdatePostData();
                    if (m_PostData == null) return;
    
                    if (!Directory.Exists(Path.GetDirectoryName(filepath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filepath));
                    }
    
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }
    
                    using (FileStream output = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                    {
                        output.Write(m_PostData, 0, m_PostData.Length);
                    }
                }
                catch (Exception e)
                {
                    // report error
                }
            }
    
            private void AppendBuffer(byte[] newBuffer, int length)
            {
                // we need to keep a running buffer here, the last 1024 bytes?  how best to find the end boundary?  need to determine when the stream is finished!
                m_TempBuffer.Write(newBuffer, length);
                if (m_IsFileUpload)
                {
                    if (m_EndBoundaryIndex < 0)
                    {
                        m_EndBoundaryIndex = StreamHelper.LastIndexOf(m_TempBuffer.RawBytes, m_TempBuffer.Count, m_EndBoundaryBytes);
    
                        if (!IsLargeFileUpload && m_EndBoundaryIndex > -1)
                        {
                            m_EndBoundaryIndex = (m_FullBuffer.Length + length) - (m_TempBuffer.Count - m_EndBoundaryIndex);
                        }
                    }
                    if (m_StartBoundaryIndex < 0)
                    {
                        m_StartBoundaryIndex = StreamHelper.IndexOf(m_FullBuffer, m_StartBoundaryBytes);
    
                        if (m_StartBoundaryIndex > -1)
                        {
                            m_StartBoundaryIndex = StreamHelper.IndexOf(m_FullBuffer, Encoding.UTF8.GetBytes("\r\n\r\n"), m_StartBoundaryIndex + m_StartBoundaryBytes.Length) + 4;
                        }
                    }
                }
    
                if (m_StartBoundaryIndex == -1 || !IsLargeFileUpload) // if this is not a file upload because no start boundary has been found then write buffer to memory
                {
                    m_FullBuffer.Write(newBuffer, 0, length);
                }
                else
                {
                    if (!m_FileCreated) // we have never written to the file, dump the contents of the full buffer now
                    {
                        bool exists = true;
    
                        while (exists)
                        {
                            m_TempFilename = Config.StaticConfig.TempFolder + "/" + Path.GetRandomFileName();
                            exists = File.Exists(m_TempFilename);
                        }
    
                        m_FileStream = new FileStream(m_TempFilename, FileMode.Create, FileAccess.Write);
    
                        m_FullBuffer.Position = m_StartBoundaryIndex;
                        m_FullBuffer.CopyTo(m_FileStream);
                        m_FileStream.Write(newBuffer, 0, length);
    
                        m_FileCreated = true;
                    }
                    else // we have previously written to the file, append new bytes
                    {
                        if (m_EndBoundaryIndex == -1)
                        {
                            m_FileStream.Write(newBuffer, 0, length);
                        }
                        else
                        {
                            m_FileStream.Write(newBuffer, 0, length - m_EndBoundaryBytes.Length);
                        }
                    }
                }
            }
    
            private void NormalRead()
            {
                try
                {
                    int bufferSize = m_Buffer.Length;
                    int bytesRead = m_Client.Client.Receive(m_Buffer, bufferSize, 0);
    
                    while (bytesRead > 0 && !m_IsDisposed)
                    {
                        m_LastRead = DateTime.Now;
                        m_BytesRead += bytesRead;
    
                        if (!m_HasHeaders || m_RequestType == RequestType.GET)
                        {
                            string sBuffer = Encoding.ASCII.GetString(m_Buffer, 0, bytesRead);
                            m_ReadData += sBuffer;
                        }
    
                        AppendBuffer(m_Buffer, bytesRead);
                        m_HasHeaders = UpdateUniqueHeaders();
    
                        if (!m_HasHeaders && m_BytesRead > 1024)
                        {
                            Program.BlacklistIP(m_RemoteIP, m_ReadData, "No HTTP headers found in the first 1024 bytes");
                            return;
                        }
    
                        if (m_RequestType != RequestType.POST)
                        {
                            break; // process the request
                        }
                        else if (m_EndBoundaryIndex != -1)
                        {
                            break; // process the request, we found our end boundary for posted data
                        }
    
                        bytesRead = m_Client.Client.Receive(m_Buffer, bufferSize, 0);
                    }
    
                    ProcessRequest(m_ReadData);
                }
                catch (Exception e)
                {
                    // report error
                }
            }
    
            private void SslRead(IAsyncResult ar)
            {
                if (m_IsDisposed) return;
    
                try
                {
                    int byteCount = -1;
                    int bufferSize = m_Buffer.Length;
    
                    m_LastRead = DateTime.Now;
                    byteCount = m_NetworkStream.EndRead(ar);
                    m_BytesRead += byteCount;
    
                    if (!m_HasHeaders || m_RequestType == RequestType.GET)
                    {
                        string sBuffer = Encoding.ASCII.GetString(m_Buffer, 0, byteCount);
                        m_ReadData += sBuffer;
                    }
    
                    AppendBuffer(m_Buffer, byteCount);
                    m_HasHeaders = UpdateUniqueHeaders();
    
                    if (!m_HasHeaders && m_BytesRead > 1024)
                    {
                        Program.BlacklistIP(m_RemoteIP, m_ReadData, "No HTTP headers found in the first 1024 bytes");
                        return;
                    }
    
                    if (byteCount > 0)
                    {
                        if (m_RequestType != RequestType.POST && m_RequestType != RequestType.None)
                        {
                            m_NetworkStream.BeginRead(m_Buffer, 0, bufferSize, new AsyncCallback(SslRead), m_NetworkStream);
                        }
                        else if (m_EndBoundaryIndex == -1) // as long as we haven't found the end of the stream continue reading
                        {
                            m_NetworkStream.BeginRead(m_Buffer, 0, bufferSize, new AsyncCallback(SslRead), m_NetworkStream);
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    return;
                }
    
                ProcessRequest(m_ReadData);
            }
    
            private bool UpdateUniqueHeaders()
            {
                if (m_RequestType == RequestType.None && m_ReadData.Length > 8)
                {
                    m_RequestType = (m_ReadData.StartsWith("GET ") ? RequestType.GET : m_RequestType);
                    m_RequestType = (m_ReadData.StartsWith("POST ") ? RequestType.POST : m_RequestType);
                    m_RequestType = (m_ReadData.StartsWith("OPTIONS ") ? RequestType.OPTIONS : m_RequestType);
                }
    
                if (m_RequestType == RequestType.GET || m_RequestType == RequestType.POST)
                {
                    string request = m_ReadData;
    
                    if (string.IsNullOrEmpty(m_HttpVersion)) m_HttpVersion = m_ReadData.Substring(request.IndexOf("HTTP", 1), 8);
                    if (string.IsNullOrEmpty(m_ContentType)) m_ContentType = GetHeader(request, "Content-Type");
                    if (m_ContentLength == 0)
                    {
                        int cLength = 0;
                        int.TryParse(GetHeader(request, "Content-Length"), out cLength);
                        m_ContentLength = cLength;
    
                        if (m_ContentLength / 1024 / 1024 > 20)
                        {
                            IsLargeFileUpload = true; // data is sent directly to a file instead of saving in memory
                        }
                    }
                }
    
                if (m_RequestType != RequestType.None && !string.IsNullOrEmpty(m_HttpVersion) && (!string.IsNullOrEmpty(m_ContentType) || m_RequestType != RequestType.POST))
                {
                    if (m_RequestType == RequestType.POST)
                    {
                        try
                        {
                            if (m_IsFileUpload == false)
                            {
                                m_IsFileUpload = Segments[1].Replace("/", "") == "upload";
                            }
                        }
                        catch { }
    
                        if (m_RequestType == RequestType.POST && m_StartBoundaryBytes == null)
                        {
                            m_StartBoundaryBytes = Encoding.ASCII.GetBytes(GetStartBoundary());
                            m_EndBoundaryBytes = Encoding.ASCII.GetBytes(GetEndBoundary());
                        }
                    }
    
                    if (string.IsNullOrEmpty(m_Request) && m_Segments.Length <= 1 && m_QueryString == null)
                    {
                        // Extract the Requested Type and Requested file/directory
                        string m_Request = m_ReadData.Substring(0, m_ReadData.IndexOf("HTTP", 1) - 1);
    
                        //Replace backslash with Forward Slash, if Any
                        m_Request = m_Request.Replace("\\", "/");
                        m_Request = m_Request.Replace("GET ", "");
                        m_Request = m_Request.Replace("POST ", "");
    
                        Uri uri = new Uri("http://localhost" + m_Request);
                        NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);
                        //SendHeader(sHttpVersion, "image/jpeg", Program.BlankImageBuffer.Length, " 200 OK");
    
                        m_AbsoluteURI = m_Request;
                        m_Segments = uri.Segments;
                        m_QueryString = query;
                    }
    
                    if (m_RequestType != RequestType.POST)
                    {
                        return true;
                    }
                    else if (m_ContentLength > 0 && m_EndBoundaryBytes != null)
                    {
                        return true;
                    }
                }
    
                return false;
            }
    
            private string GetStartBoundary()
            {
                return "--" + m_ContentType.Split(';')[1].Split('=')[1];
            }
    
            private string GetEndBoundary()
            {
                return "--" + m_ContentType.Split(';')[1].Split('=')[1] + "--\r\n";
            }
    
            private string GetHeader(string request, string key)
            {
                string result = string.Empty;
                int iStartPos = request.IndexOf(key + ":", 0) + key.Length + 1;
    
                if (request.IndexOf(key + ":", 0) > -1)
                {
                    // Get the HTTP text and version e.g. it will return "HTTP/1.1"
                    int iEndPos = request.IndexOf("\r\n", iStartPos);
                    result = request.Substring(iStartPos, iEndPos - iStartPos).Trim();
                }
    
                return result;
            }
    
            private void CleanFile()
            {
                try
                {
                    if (!string.IsNullOrEmpty(m_TempFilename) && File.Exists(m_TempFilename))
                    {
                        using (Stream stream = File.Open(m_TempFilename, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1024];
                            stream.Read(buffer, 0, buffer.Length);
                            //stream.Position = 0;
                            //stream.Write(data, 0, data.Length);
                        }
                    }
                }
                catch { }
            }
    
            private void ProcessRequest(string request)
            {
                try
                {
                    if (request.Length < 5) return;
    
                    List<string> headers = null;
                    if (request.StartsWith("OPTIONS"))
                    {
                        headers = GetCommonHeader("", 0);
                        headers.Add("Access-Control-Allow-Credentials: true");
                        headers.Add("Access-Control-Allow-Headers: Authorization, X-Mashape-Authorization, Accept, Content-Type, X-Requested-With, X-PINGOTHER, X-File-Name, Cache-Control");
                        headers.Add("Access-Control-Allow-Methods: PUT, POST, GET, OPTIONS");
                        headers.Add("Keep-Alive: timeout=15,max=100");
                        headers.Add("Access-Control-Allow-Origin: *");
                        headers.Add("Connection: close");
    
                        SendHeader(headers);
                        return;
                    }
    
                    UpdateUniqueHeaders();
                    CleanFile();
                    CloseFile();
    
                    if (m_Timer_Check != null) m_Timer_Check.Dispose();
                    string responseText = Program.ProcessRequest(this);
                    if (string.IsNullOrEmpty(responseText)) responseText = "\r\n";
    
                    byte[] buf = Encoding.ASCII.GetBytes(responseText);
                    headers = GetCommonHeader("text/html", buf.Length, " 200 OK");
                    headers.Add("Access-Control-Allow-Origin: *");
                    SendHeaderAndData(headers, buf);
                }
                catch (Exception e) { }
                finally
                {
                    Dispose();
                }
            }
    
            private void CloseFile()
            {
                try
                {
                    if (m_FileStream != null)
                    {
                        m_FileStream.Dispose();
                        m_FileStream = null;
                    }
                }
                catch { }
            }
    
            /// <summary>
            /// This function send the Header Information to the client (Browser)
            /// </summary>
            /// <param name="sHttpVersion">HTTP Version</param>
            /// <param name="sMIMEHeader">Mime Type</param>
            /// <param name="iTotBytes">Total Bytes to be sent in the body</param>
            /// <param name="mySocket">Socket reference</param>
            /// <returns></returns>
            public List<string> GetCommonHeader(string mimeHeader = "text/html", int length = -1, string sStatusCode = " 200 OK", string filename = "", bool chunked = false)
            {
                // if Mime type is not provided set default to text/html
    
                List<string> headers = new List<string>();
    
                headers.Add(m_HttpVersion + sStatusCode);
                headers.Add("Server: ExampleTcpWebServer");
    
                if (!string.IsNullOrEmpty(mimeHeader))
                {
                    headers.Add("Content-Type: " + mimeHeader);
                }
    
                if (length > -1)
                {
                    headers.Add("Content-Length: " + length);
                }
    
                headers.Add("Date: " + DateTime.Now.ToUniversalTime().ToString("ddd, d MMM yyyy HH:mm:ss") + " GMT");
    
                if (!string.IsNullOrEmpty(filename))
                {
                    headers.Add("Content-Disposition: attachment; filename=\"" + filename + "\"");
                }
                if (chunked)
                {
                    headers.Add("Transfer-Encoding: chunked");
                }
    
                return headers;
            }
    
            public void SendHeader(List<string> headers)
            {
                string sHeader = string.Empty;
    
                foreach (string header in headers)
                {
                    sHeader += header + "\r\n";
                }
    
                sHeader += "\r\n";
    
                byte[] bSendData = Encoding.ASCII.GetBytes(sHeader);
                SendToBrowser(bSendData, bSendData.Length);
            }
    
            public void SendHeaderAndData(List<string> headers, byte[] data)
            {
                string sHeader = string.Empty;
    
                foreach (string header in headers)
                {
                    sHeader += header + "\r\n";
                }
    
                sHeader += "\r\n";
    
                byte[] bHeader = Encoding.ASCII.GetBytes(sHeader);
                byte[] combined = new byte[bHeader.Length + data.Length];
    
                Array.Copy(bHeader, combined, bHeader.Length);
                Array.Copy(data, 0, combined, bHeader.Length, data.Length);
    
                SendToBrowser(combined, combined.Length);
            }
    
            /// <summary>
            /// Sends data to the browser (client)
            /// </summary>
            /// <param name="bSendData">Byte Array</param>
            /// <param name="mySocket">Socket reference</param>
            public void SendToBrowser(byte[] bSendData, int length)
            {
                try
                {
                    if (Common.TcpHelper.SocketConnected(m_Client.Client))
                    {
                        if (m_IsSSL)
                        {
                            m_NetworkStream.Write(bSendData, 0, length);
                        }
                        else
                        {
                            m_Client.Client.Send(bSendData, length, 0);
                        }
                    }
                    else
                    {
                        Dispose();
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Error Occurred : {0} ", e);
                }
            }
    
            #endregion private methods
    
            #region IDisposable
    
            public void Dispose()
            {
                if (!m_IsDisposed)
                {
                    m_IsDisposed = true;
    
                    try
                    {
                        if (!string.IsNullOrEmpty(m_TempFilename) && File.Exists(m_TempFilename))
                        {
                            File.Delete(m_TempFilename);
                        }
                    }
                    catch { }
    
                    CloseFile();
    
                    try
                    {
                        m_Client.Client.Close(5);
                        m_Client.Close();
                        m_Client.Client.Dispose();
                    }
                    catch { }
    
                    try
                    {
                        m_NetworkStream.Dispose();
                    }
                    catch { }
    
                    try
                    {
                        if (Thread.CurrentThread != m_Thread_Read && m_Thread_Read.IsAlive)
                        {
                            m_Thread_Read.Join(1000);
                            if (m_Thread_Read.IsAlive) m_Thread_Read.Abort();
                        }
                    }
                    catch { }
    
                    try
                    {
                        m_ReadData = null;
                        m_PostData = null;
                        m_Buffer = null;
                        m_TempBuffer = null;
    
                        if (m_FullBuffer != null) m_FullBuffer.Dispose();
                        if (m_Timer_Check != null) m_Timer_Check.Dispose();
                        m_Timer_Check = null;
                    }
                    catch { }
                }
            }
    
            #endregion IDisposable
        }
    }
