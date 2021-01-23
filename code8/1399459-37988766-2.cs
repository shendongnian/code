    class readMail:IDisposable
        {
            public Imap4Client client = new Imap4Client();
            public readMail(string mailServer, int port, bool ssl, string login, string password)
            {
                Pop3Client pop = new Pop3Client();
                if (ssl)
                {
                    client.ConnectSsl(mailServer, port);
                }
                else
                client.Connect(mailServer, port);
                client.Login(login, password);
            }
            public IEnumerable<Message> GetAllMails(string mailBox)
            {
                IEnumerable<Message> ms = GetMails(mailBox, "ALL").Cast<Message>();
                return GetMails(mailBox, "ALL").Cast<Message>();
            }
            
            protected Imap4Client Client
            {
                get { return client ?? (client = new Imap4Client()); }
            }
            private MessageCollection GetMails(string mailBox, string searchPhrase)
            {
                try
                {
                    MessageCollection messages = new MessageCollection();
                    Mailbox mails = new Mailbox();
                    mails = Client.SelectMailbox(mailBox);
                    messages = mails.SearchParse(searchPhrase);
                    return messages;
                }
                catch(Exception ecc)
                {
                    
                }
                
            }
    
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
