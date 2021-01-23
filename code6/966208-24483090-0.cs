    public struct SMTPTestResult
    {
        public string Server;
        public bool Found;
        public bool OriginalPortSuccess;
        public int FinalPort;
        public bool UsedSSL;
        public string Response;
    }
    public class SMTPTest
    {
        public static SMTPTestResult TestMailServer(string MailServer)
        {
            return TestMailServer(MailServer, 25, true);
        }
        public static SMTPTestResult TestMailServer(string MailServer, int Port, bool TryOtherPorts)
        {
            SMTPTestResult result = new SMTPTestResult();
            result.Server = MailServer;
            if (AttemptMailServer(MailServer, Port, false, out result.Response))
            {
                //First try the requested port, without SSL.
                result.Found = true;
                result.UsedSSL = false;
                result.OriginalPortSuccess = true;
                result.FinalPort = Port;
                return result;
            }
            else if (AttemptMailServer(MailServer, Port, true, out result.Response))
            {
                //Try the requested port, with SSL.
                result.Found = true;
                result.UsedSSL = true;
                result.OriginalPortSuccess = true;
                result.FinalPort = Port;
                return result;
            }
            else if (TryOtherPorts && Port != 465 && AttemptMailServer(MailServer, 465, true, out result.Response))
            {
                //Try port 465 with SSL
                result.Found = true;
                result.UsedSSL = true;
                result.OriginalPortSuccess = false;
                result.FinalPort = 465;
                return result;
            }
            else if (TryOtherPorts && Port != 25 && AttemptMailServer(MailServer, 25, false, out result.Response))
            {
                //Try port 25, without SSL.
                result.Found = true;
                result.UsedSSL = false;
                result.OriginalPortSuccess = false;
                result.FinalPort = 25;
                return result;
            }
            else if (TryOtherPorts && Port != 25 && AttemptMailServer(MailServer, 25, true, out result.Response))
            {
                //Try port 25, with SSL.
                result.Found = true;
                result.UsedSSL = true;
                result.OriginalPortSuccess = false;
                result.FinalPort = 25;
                return result;
            }
            else if (TryOtherPorts && Port != 587 && AttemptMailServer(MailServer, 587, false, out result.Response))
            {
                //Try port 587, without SSL.
                result.Found = true;
                result.UsedSSL = false;
                result.OriginalPortSuccess = false;
                result.FinalPort = 587;
                return result;
            }
            else if (TryOtherPorts && Port != 587 && AttemptMailServer(MailServer, 587, true, out result.Response))
            {
                //Try port 587, with SSL.
                result.Found = true;
                result.UsedSSL = true;
                result.OriginalPortSuccess = false;
                result.FinalPort = 587;
                return result;
            }
            else
            {
                result.Found = false;
                result.OriginalPortSuccess = false;
                result.FinalPort = Port;
                return result;
            }
        }
        private static bool AttemptMailServer(string strMailServer, int intPort, bool blnSSL, out string strResponse)
        {
            try
            {
                if(!blnSSL)
                {
                    //I'll try a basic SMTP HELO
                    using (var client = new TcpClient())
                    {
                        client.Connect(strMailServer, intPort);
                        using (var stream = client.GetStream())
                        {
                            using (var writer = new StreamWriter(stream))
                            using (var reader = new StreamReader(stream))
                            {
                                writer.WriteLine("EHLO " + strMailServer);
                                writer.Flush();
                                strResponse = reader.ReadLine();
                                if (strResponse == null)
                                    throw new Exception("No Valid Connection");
                                stream.Close();
                                client.Close();
                                if (strResponse.StartsWith("220"))
                                    return true;
                                else
                                    return false;
                            }
                        }
                    }
                }
                else
                {
                    //I'll try with SSL
                    using (var client = new TcpClient())
                    {
                        client.Connect(strMailServer, intPort);
                        // As GMail requires SSL we should use SslStream
                        // If your SMTP server doesn't support SSL you can
                        // work directly with the underlying stream
                        using (var stream = client.GetStream())
                        using (var sslStream = new SslStream(stream))
                        {
                            sslStream.AuthenticateAsClient(strMailServer);
                            using (var writer = new StreamWriter(sslStream))
                            using (var reader = new StreamReader(sslStream))
                            {
                                writer.WriteLine("EHLO " + strMailServer);
                                writer.Flush();
                                strResponse = reader.ReadLine();
                                if (strResponse == null)
                                    throw new Exception("No Valid Connection");
                                stream.Close();
                                client.Close();
                                if (strResponse.StartsWith("220"))
                                    return true;
                                else
                                    return false;
                                // GMail responds with: 220 mx.google.com ESMTP
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponse = ex.Message;
                return false;
            }
        }
    }
