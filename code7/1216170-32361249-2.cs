    ConcurrentBag<ServerSocks> list = loadSocks();
    var oServer = new SmtpServer("");
    for (int i = 0; i < nRcpt; i++)
    {
        while (!list.IsEmpty)
        {
            try
            {   
                //code here to send message using below IP and Port
                oServer.SocksProxyServer = list[i%list.count].IpAddress;
                oServer.SocksProxyPort = list[i%list.count].Port;
                arMail[i] = new SmtpMail("TryIt");
                arSmtp[i] = new SmtpClient();
                SmtpMail oMail = arMail[i];
                oMail.From = "";
                //oMail.DKCertificate
                oMail.Sender = "";
                oMail.Subject = "";
                oMail.TextBody = "";
                oMail.AutoTextBody = false;
                try
                {
                    string fileHtml = Path.GetFullPath(Path.Combine(Application.StartupPath, "lettercmb.html"));
                    oMail.ImportHtmlBody(fileHtml, ImportHtmlBodyOptions.NoOptions);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                SmtpClient oSmtp = arSmtp[i];
                Console.WriteLine(oServer.SocksProxyServer);
                Console.ReadLine();
                arResult[i] = oSmtp.BeginSendMail(oServer, oMail, null, null);
                Console.WriteLine(String.Format("Start to send email to {0} ...",
                             arRcpt[i]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
            }        
        }
