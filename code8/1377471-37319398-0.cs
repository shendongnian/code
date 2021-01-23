     using System.Collections.Generic;
        using System.Linq;
        using ActiveUp.Net.Mail;
        using ActiveUp.Net.Security;
        using System.Diagnostics;
        using System;
        
    namespace servizioWiki
    {
        class readMail
        {
            public Imap4Client client = new Imap4Client();
            public readMail(string mailServer, int port, bool ssl, string login, string password)
            {
               
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
                return GetMails(mailBox, "ALL").Cast<Message>();
            }
            public IEnumerable<Message> GetUnreadMails(string mailBox)
            {
                return GetMails(mailBox, "UNSEEN").Cast<Message>();
            }
            protected Imap4Client Client
            {
                get { return client ?? (client = new Imap4Client()); }
            }
            private MessageCollection GetMails(string mailBox, string searchPhrase)
            {
                try
                {
                    Mailbox mails = Client.SelectMailbox(mailBox);
                    MessageCollection messages = mails.SearchParse(searchPhrase);
                    return messages;
                }
                catch(Exception ecc)
                {
                    EventLog Log = new EventLog("Application");
                    Log.Source = "ServizioWiki";
                    Log.WriteEntry("Errore durante la lettura delle mail, dettagli: " + ecc.Message, EventLogEntryType.Warning);
                    return null;
                }
                
            }
    
        }
    
