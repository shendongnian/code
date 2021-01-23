    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Net.Mail;
    
    namespace General.Utilities.Mail
    {
        public class SMTPSendRawMIME
        {
        #region Constructor
        public SMTPSendRawMIME()
        {
        }
        #endregion
        //The following methods are KNOWN to be flawed... they work only with some SMTP Servers... not many.... 
        //On the other hand, they run very fast... so they are worth using when possible like with SendGrid
        #region Send Raw Mime
        #region Static Send Methods
        public static void SendEmail(SmtpClient Server, string FromEmail, string ToEmail, byte[] MIMEMessage) //bool SSL, 
        {
            SMTPSendRawMIME objMailClient = new SMTPSendRawMIME();
            objMailClient.Send(Server, FromEmail, ToEmail, MIMEMessage);
        }
        public static void SendEmail(General.Utilities.Mail.MailTools.MailServerTypes enuUseServerType, string FromEmail, string ToEmail, byte[] MIMEMessage) //bool SSL, 
        {
            SmtpClient objServer = General.Utilities.Mail.MailTools.GetMailServer(enuUseServerType);
            SMTPSendRawMIME objMailClient = new SMTPSendRawMIME();
            objMailClient.Send(objServer, FromEmail, ToEmail, MIMEMessage);
        }
        #endregion
        public void Send(SmtpClient Server, string FromEmail, string ToEmail, byte[] MIMEMessage) //bool SSL, 
        {
            if (Server.Credentials != null)
            {
                //if (SSL)
                    //SendSSL(Server.Host, Server.Port, ((NetworkCredential)Server.Credentials).UserName, ((NetworkCredential)Server.Credentials).Password, FromEmail, ToEmail, MIMEMessage);
                //else
                    Send(Server.Host, Server.Port, ((NetworkCredential)Server.Credentials).UserName, ((NetworkCredential)Server.Credentials).Password, FromEmail, ToEmail, MIMEMessage);
            }
            else
            {
                SendToOpenRelay(Server.Host, Server.Port, FromEmail, ToEmail, MIMEMessage);
            }
            
        }
        #region BASE Send
        /// <summary>
        /// Sends the message via a socket connection to an SMTP relay host. 
        /// </summary>
        /// <param name="hostname">Friendly-name or IP address of SMTP relay host</param>
        /// <param name="port">Port on which to connect to SMTP relay host</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Send(string HostName, int Port, string UserName, string Password, string FromEmail, string ToEmail, byte[] MIMEMessage)
        {
            const int bufsize = 1000;
            TcpClient smtp;
            NetworkStream ns;
            int cb, startOfBlock;
            byte[] recv = new byte[bufsize];
            byte[] data;
            string message, block;
            try
            {
                
                smtp = new TcpClient(HostName, Port);
                ns = smtp.GetStream();
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                message = "EHLO\r\n";
                System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Unable to establish SMTP session with {0}:{1}", HostName, Port), ex);
            }
            try
            {
                //figure out the line containing 250-AUTH
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                startOfBlock = message.IndexOf("250-AUTH");
                block = message.Substring(startOfBlock, message.IndexOf("\n", startOfBlock) - startOfBlock);
                //check the auth protocols
                if (-1 == block.IndexOf("LOGIN"))
                    throw new Exception("Mailhost does not support LOGIN authentication");
                message = "AUTH LOGIN\r\n";
                //System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("334"))
                    throw new Exception(string.Format("Unexpected reply to AUTH LOGIN:\n{0}", message));
                message = string.Format("{0}\r\n", Convert.ToBase64String(Encoding.ASCII.GetBytes(UserName)));
                //System.Diagnostics.Debug.WriteLine(message, "Client (username)");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("334"))
                    throw new Exception(string.Format("Unexpected reply to username:\n{0}", message));
                message = string.Format("{0}\r\n", Convert.ToBase64String(Encoding.ASCII.GetBytes(Password)));
                //System.Diagnostics.Debug.WriteLine(message, "Client (password)");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                if (message.StartsWith("535"))
                    throw new Exception("Authentication unsuccessful");
                if (!message.StartsWith("2"))
                    throw new Exception(string.Format("Unexpected reply to password:\n{0}", message));
                message = string.Format("MAIL FROM: <{0}>\r\n", FromEmail);
                //System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("250"))
                    throw new Exception(string.Format("Unexpected reply to MAIL FROM:\n{0}", message));
                message = string.Format("RCPT TO: <{0}>\r\n", ToEmail);
                string strRcptToMessage = message;
                //System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("250"))
                    throw new Exception(string.Format("Unexpected reply to RCPT TO:\n{0}", message + " (" + strRcptToMessage + ")"));
                message = "DATA\r\n";
                //System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("354"))
                    throw new Exception(string.Format("Unexpected reply to DATA:\n{0}", message));
                //message = payload + "\r\n.\r\n";
                //data = Encoding.ASCII.GetBytes(Encoding.UTF8.GetString(MIMEMessage) + "\r\n.\r\n");
                data = MIMEMessage;
                ns.Write(data, 0, data.Length);
                message = "\r\n.\r\n";
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                //System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("250"))
                    throw new Exception(string.Format("Unexpected reply to end of data marker (\\r\\n.\\r\\n):\n{0}", message));
                message = "QUIT\r\n";
                //System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                General.Utilities.Debugging.Report.SendError("SMTP Communication Error", ex);
                throw new Exception(string.Format("SMTP Communication Error: {0}", message), ex);
            }
            finally
            {
                if (null != smtp) smtp.Close();
            }
        }
        #endregion
        #region BASE SendSSL
        /// <summary>
        /// Sends the message via a socket connection to an SMTP relay host. 
        /// </summary>
        /// <param name="hostname">Friendly-name or IP address of SMTP relay host</param>
        /// <param name="port">Port on which to connect to SMTP relay host</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        private void SendSSL(string HostName, int Port, string UserName, string Password, string FromEmail, string ToEmail, byte[] MIMEMessage)
        {
            //This Doesn't Work Yet... :(
            const int bufsize = 1000;
            TcpClient smtp;
            System.Net.Security.SslStream ns;
            int cb, startOfBlock;
            byte[] recv = new byte[bufsize];
            byte[] data;
            string message, block;
            try
            {
                smtp = new TcpClient(HostName, Port);
                ns = new System.Net.Security.SslStream(smtp.GetStream(), true);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                message = "EHLO\r\n";
                System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Unable to establish SMTP session with {0}:{1}", HostName, Port), ex);
            }
            try
            {
                //figure out the line containing 250-AUTH
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                startOfBlock = message.IndexOf("250-AUTH");
                block = message.Substring(startOfBlock, message.IndexOf("\n", startOfBlock) - startOfBlock);
                //check the auth protocols
                if (-1 == block.IndexOf("LOGIN"))
                    throw new Exception("Mailhost does not support LOGIN authentication");
                message = "AUTH LOGIN\r\n";
                System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("334"))
                    throw new Exception(string.Format("Unexpected reply to AUTH LOGIN:\n{0}", message));
                message = string.Format("{0}\r\n", Convert.ToBase64String(Encoding.ASCII.GetBytes(UserName)));
                System.Diagnostics.Debug.WriteLine(message, "Client (username)");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("334"))
                    throw new Exception(string.Format("Unexpected reply to username:\n{0}", message));
                message = string.Format("{0}\r\n", Convert.ToBase64String(Encoding.ASCII.GetBytes(Password)));
                System.Diagnostics.Debug.WriteLine(message, "Client (password)");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                if (message.StartsWith("535"))
                    throw new Exception("Authentication unsuccessful");
                if (!message.StartsWith("2"))
                    throw new Exception(string.Format("Unexpected reply to password:\n{0}", message));
                message = string.Format("MAIL FROM: <{0}>\r\n", FromEmail);
                System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("250"))
                    throw new Exception(string.Format("Unexpected reply to MAIL FROM:\n{0}", message));
                message = string.Format("RCPT TO: <{0}>\r\n", ToEmail);
                System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("250"))
                    throw new Exception(string.Format("Unexpected reply to RCPT TO:\n{0}", message));
                message = "DATA\r\n";
                System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("354"))
                    throw new Exception(string.Format("Unexpected reply to DATA:\n{0}", message));
                data = MIMEMessage;
                ns.Write(data, 0, data.Length);
                message = "\r\n.\r\n";
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                clearBuf(recv);
                cb = ns.Read(recv, 0, recv.Length);
                message = Encoding.ASCII.GetString(recv);
                System.Diagnostics.Debug.WriteLine(message, "Server");
                if (!message.StartsWith("250"))
                    throw new Exception(string.Format("Unexpected reply to end of data marker (\\r\\n.\\r\\n):\n{0}", message));
                message = "QUIT\r\n";
                System.Diagnostics.Debug.WriteLine(message, "Client");
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SMTP Communication Error: {0}", message), ex);
            }
            finally
            {
                if (null != smtp) smtp.Close();
            }
        }
        #endregion
        #region BASE SendToOpenRelay
        /// <summary>
        /// Sends the message via a socket connection to an SMTP relay host. 
        /// </summary>
        /// <param name="hostname">Friendly-name or IP address of SMTP relay host</param>
        /// <param name="port">Port on which to connect to SMTP relay host</param>
        public void SendToOpenRelay(string HostName, int Port, string FromEmail, string ToEmail, byte[] MIMEMessage)
        {
            TcpClient smtp;
            NetworkStream ns;
            int cb;
            byte[] recv = new byte[256];
            byte[] data;
            string message;
            try
            {
                smtp = new TcpClient(HostName, Port);
                ns = smtp.GetStream();
                message = "HELO\r\n";
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                cb = ns.Read(recv, 0, recv.Length);
                System.Diagnostics.Debug.WriteLine(Encoding.ASCII.GetString(recv), "Server");
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Unable to establish SMTP session with {0}:{1}", HostName, Port), ex);
            }
            try
            {
                message = string.Format("MAIL FROM: <{0}>\r\n", FromEmail);
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                cb = ns.Read(recv, 0, recv.Length);
                if (!Convert.ToString(recv).StartsWith("501"))
                    throw new Exception("Malformed sender address");
                if (!Convert.ToString(recv).StartsWith("250"))
                    throw new Exception(string.Format("SMTP host responded incorrectly to MAIL FROM:, response was:\n{0}", Convert.ToString(recv)));
                message = string.Format("RCPT TO: <{0}>\r\n", ToEmail);
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                cb = ns.Read(recv, 0, recv.Length);
                if (Convert.ToString(recv).StartsWith("501"))
                    throw new Exception("Malformed recipient address");
                if (!Convert.ToString(recv).StartsWith("250"))
                    throw new Exception(string.Format("SMTP host responded incorrectly to RCPT TO:, response was:\n{0}", Convert.ToString(recv)));
                message = "DATA\r\n";
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                cb = ns.Read(recv, 0, recv.Length);
                if (!Convert.ToString(recv).StartsWith("354"))
                    throw new Exception(string.Format("SMTP host responded incorrectly to DATA, response was:\n{0}", Convert.ToString(recv)));
                data = MIMEMessage;
                ns.Write(data, 0, data.Length);
                message = "\r\n.\r\n";
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                cb = ns.Read(recv, 0, recv.Length);
                message = "QUIT\r\n";
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
    
          
                    throw new Exception(string.Format("SMTP Communication Error: {0}", message), ex);
                }
                finally
                {
                    if (null != smtp) smtp.Close();
                }
            }
            #endregion
    
            #region clearBuf
            private void clearBuf(byte[] buf)
            {
                for (int i = 0; i < buf.Length; i++) buf[i] = 0;
            }
            #endregion
    
            #endregion
    
        }
    }
