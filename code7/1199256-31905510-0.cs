    using MyProject.Logic;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MyProject.Model
    {
        public class MultiPartStream : Stream
        {
            private HttpWebResponse response;
            private Stream currentStream;
            private List<KeyValuePair<string, long>> parts = new List<KeyValuePair<string,long>>();
    
            private Stopwatch timer = new Stopwatch();
            private long totalStreamSize;
            private long bytesRead;
            private string file;
            private int currentPart = 0;
    
            public MultiPartStream(string file)
            {
                this.file = file;
                GetParts();
                NextStream();
            }
    
            public MultiPartStream(string file, string url)
            {
                this.file = file;
                GetPart(url, false);
                NextStream();
            }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                if (!timer.IsRunning)
                    timer.Start();
    
                int bytesRead = currentStream.Read(buffer, offset, count);
                if (bytesRead <= 0 && currentPart < parts.Count - 1)
                {
                    // if we cannot read from the Stream anymore, we open the next Stream if one is available
                    currentPart++;
                    NextStream();
                    bytesRead = Read(buffer, offset, count);
                }
                this.bytesRead += bytesRead;
    
                return (int)bytesRead;
            }
    
            protected override void Dispose(bool disposing)
            {
                timer.Stop();
                base.Dispose(disposing);
            }
    
            private void GetParts()
            {
                if (!this.GetPart(DownloadHelper.Instance.GetSingleFileUrl(file)))
                {
                    int filePart = 1;
                    while (this.GetPart(DownloadHelper.Instance.GetMultiFileUrl(file, filePart)))
                    {
                        filePart++;
                    }
                }
            }
    
            private bool GetPart(string url, bool suppressApplicationException = true)
            {
                bool thisPartAdded = false;
    
                HttpWebRequest request = HttpWebRequest.CreateHttp(url);
    
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (request.HaveResponse && response.StatusCode == HttpStatusCode.OK)
                    {
                        parts.Add(new KeyValuePair<string, long>(url, response.ContentLength));
                        totalStreamSize += response.ContentLength;
                        thisPartAdded = true;
                    }
                    response.Close();
                }
                catch (WebException e)
                {
                    if (!suppressApplicationException)
                        throw new ApplicationException(String.Format("Error: cannot access file '{0}' ({1}: {2})", url, e.Status, e.Message));
                }
    
                return thisPartAdded;
            }
    
            private void NextStream()
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
    
                HttpWebRequest request = HttpWebRequest.CreateHttp(parts[currentPart].Key);
    
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    if (request.HaveResponse && response.StatusCode == HttpStatusCode.OK)
                    {
                        currentStream = response.GetResponseStream();
                    }
                }
                catch (WebException e)
                {
                    throw new ApplicationException(String.Format("Error: could not open file '{0}' for streaming ({1}: {2})", parts[currentPart].Key, e.Status, e.Message));
                }
            }
    
            public long TotalStreamSize
            {
                get { return totalStreamSize; }
            }
    
            public string TransferSpeed
            {
                get
                {
                    float transferSpeed = (float)(bytesRead / 1024f) / (timer.ElapsedMilliseconds / 1000f);
                    if (transferSpeed > 1024f)
                    {
                        return "@ " + Math.Round(transferSpeed / 1024f, 2) + " mb / s";
                    }
                    else
                    {
                        return "@ " + Math.Round(transferSpeed, 2) + " kb / s";
                    }
                }
            }
    
            #region Remaining Stream-methods
            public override long Position
            {
                get
                {
                    long valueToCompare = 0;
                    for (int index = 0; index < currentPart; index++)
                    {
                        valueToCompare += parts[index].Value;
                    }
                    return valueToCompare + currentStream.Position;
                }
                set
                {
                    long valueToCompare = 0;
                    for (int index = 0; index < parts.Count; index++)
                    {
                        valueToCompare += parts[index].Value;
                        if (value <= valueToCompare)
                        {
                            currentPart = index;
                            NextStream();
                            currentStream.Position = value - (valueToCompare - parts[index].Value);
                        }
                    }
                }
            }
    
            public override bool CanRead
            {
                get { return true; }
            }
    
            public override bool CanSeek
            {
                get { return false; }
            }
    
            public override bool CanWrite
            {
                get { return false; }
            }
    
            public override void Flush()
            {
				if (currentPart > 0)
				{
					currentPart = 0;
					NextStream();
				}
				else if (currentPart == 0)
				{
					currentStream.Flush();
				}
            }
    
            public override long Length
            {
                get { return totalStreamSize; }
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
    
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            #endregion
        }
    }
