    using System;
    
    using MailKit.Net.Imap;
    using MailKit.Search;
    using MailKit;
    using MimeKit;
    
    namespace TestClient {
        class Program
        {
            public static void Main (string[] args)
            {
                using (var client = new ImapClient ()) {
                    client.Connect ("imap.gmail.com", 993, true);
    
                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove ("XOAUTH2");
    
                    client.Authenticate (username, password);
    
                    // Get a reference to the personal namespace as a folder:
                    var personal = client.GetFolder (client.PersonalNamespaces[0]);
    
                    // Get a list of subfolders within our personal namespace:
                    foreach (var folder in personal.GetSubfolders ()) {
                        Console.WriteLine ("Name: {0}", folder.Name);
    
                        // To get the message count, we either need to Open()
                        // the folder or we can call Status() to just get
                        // the properties that we care about:
                        folder.Status (StatusItems.Count | StatusItems.Unread);
    
                        Console.WriteLine ("Count: {0}", folder.Count);
                        Console.WriteLine ("Unread: {0}", folder.Unread);
    
                        // If we want to fetch any of the messages (or get any
                        // message metadata, we'll need to actually Open() the
                        // folder:
                        folder.Open (FolderAccess.ReadWrite);
    
                        for (int i = 0; i < folder.Count; i++) {
                            var message = folder.GetMessage (i);
                            Console.WriteLine ("Subject: {0}", message.Subject);
                        }
    
                        // Of course, there are many other things we can do
                        // such as searching, getting meta info about the
                        // messages (such as flags, pre-parsed envelope headers
                        // the size, etc), setting flags, getting individual
                        // parts of the message, etc.
                        // Note: we can also get subfolders of this folder...
                        foreach (var subfolder in folder.GetSubfolders ()) {
                            // ...
                        }
                    }
    
                    client.Disconnect (true);
                }
            }
        }
    }
