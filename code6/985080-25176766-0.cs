            Log.WriteLog("IMAP 4 Client Authentication Started");
            using (Imap4Client imap = new Imap4Client())
            {
                try
                {
                    imap.ConnectSsl(host, connPort);          // port 993 for SSL Connect 
                    imap.Login(username, password);
                    imap.Command("capability");
                    Log.WriteLog("IMAP 4 Client Authentication Done");
                     //fllowed by reading email from Inbox and junk emails.  
                     try
                    {
                        Monitor.Enter(_myLock);
                        ReadEmails(imap, "inbox");
                        LogHelper.WriteLogEntry("Retrieving junk e-mail unread emails started");
                        ReadEmails(imap, "junk");
                        
                    }catch(Exception ex)
                    {
                        Log.WriteLog(ex.Message);
                    }
                    finally
                    {
                        Monitor.Exit(_myLock);
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex.Message);
                }
               
            }
