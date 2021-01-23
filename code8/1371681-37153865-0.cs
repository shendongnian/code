            static CancellationTokenSource _done;
            ImapClient _imap;
            protected void Application_Start(object sender, EventArgs e)
            {
                var worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(StartIdleProcess);
    
                if (worker.IsBusy)
                    worker.CancelAsync();
    
                worker.RunWorkerAsync();
            }
    
            private void StartIdleProcess(object sender, DoWorkEventArgs e)
            {
                _imap = new ImapClient();
    
                _imap.Connect(ConfigurationManager.AppSettings["IncomingServerName"], Convert.ToInt32(ConfigurationManager.AppSettings["InPort"]), Convert.ToBoolean(ConfigurationManager.AppSettings["IncomingIsSSL"]));
                _imap.AuthenticationMechanisms.Remove("XOAUTH");
                _imap.Authenticate(ConfigurationManager.AppSettings["EmailAddress"], ConfigurationManager.AppSettings["Password"]);
    
                _imap.Inbox.Open(FolderAccess.ReadWrite);
                _imap.Inbox.MessagesArrived += Inbox_MessagesArrived;
                _done = new CancellationTokenSource();
                _imap.Idle(_done.Token);
            }
            static void Inbox_MessagesArrived(object sender, EventArgs e)
            {
                var folder = (ImapFolder)sender;
                //_done.Cancel(); // Stop idle process
                using (var client = new ImapClient())
                {
                    client.Connect(ConfigurationManager.AppSettings["IncomingServerName"], Convert.ToInt32(ConfigurationManager.AppSettings["InPort"]), Convert.ToBoolean(ConfigurationManager.AppSettings["IncomingIsSSL"]));
    
                    // disable OAuth2 authentication unless you are actually using an access_token
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
    
                    client.Authenticate(ConfigurationManager.AppSettings["EmailAddress"], ConfigurationManager.AppSettings["Password"]);
    
                    int tmpcnt = 0;
                    client.Inbox.Open(FolderAccess.ReadWrite);
                    foreach (var uid in client.Inbox.Search(SearchQuery.NotSeen))
                    {
                        try
                        {
                            var message = client.Inbox.GetMessage(uid);
                            client.Inbox.SetFlags(uid, MessageFlags.Seen, true);
    
                            List<byte[]> listAttachment = new List<byte[]>();
    
                            if (message.Attachments.Count() > 0)
                            {
                                foreach (var objAttach in message.Attachments)
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        ((MimeKit.ContentObject)(((MimeKit.MimePart)(objAttach)).ContentObject)).Stream.CopyTo(ms);
                                        byte[] objByte = ms.ToArray();
                                        listAttachment.Add(objByte);
                                    }
                                }
                            }
    
                            string subject = message.Subject;
                            string text = message.TextBody;
                            var hubContext = GlobalHost.ConnectionManager.GetHubContext<myHub>();
                            hubContext.Clients.All.modify("fromMail", text);
                            tmpcnt++;
                        }
                        catch (Exception)
                        { }
                    }
                    client.Disconnect(true);
                }
            }
