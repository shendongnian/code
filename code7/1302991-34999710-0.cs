    using System.Diagnostics; 
    using System.Net.Mail;
    using MailKit;
    using MailKit.Search;
    using MailKit.Net.Imap;
    void test()
        {
            const int period = 1000 * 60 * 5; //5 minutes
            do
            {
                using (var client = new ImapClient())
                {
                    client.Connect(serverAddress, 993, true);
                    client.Authenticate(username, password);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    SearchQuery query = SearchQuery.SubjectContains("RUNTESTING");
                    foreach (var uid in inbox.Search(query))
                    {
                        var process = Process.Start("testing.exe");
                        process.WaitForExit();
                        using (var client = new SmtpClient())
                        {
                            var message = new MimeMessage();
                            message.Subject = "Testing complete";
                            client.Connect(serverAddress, port, false);
                            client.AuthenticationMechanisms.Remove("XOAUTH2");
                            client.Authenticate(username, password);
                            client.Send(message);
                            client.Disconnect(true);
                        }
                    }
                    client.Disconnect(true);
                }
                System.Threading.Thread.Sleep(period);
            } while (true);
        }
