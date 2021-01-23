    using (readMail read = new readMail("host.name.information", port, true, username, password) )
                {
                    
                 
                    var emailList = read.GetAllMails(this.folderEmail);
                    int k = 0;
                    Mailbox bbb = read.client.SelectMailbox(this.folderEmail);
                    int[] unseen = bbb.Search("UNSEEN");
    
                    foreach (Message email in emailList)
                    {
                        
    			      /// Contains all parts for which no Content-Disposition header was found. Disposition is left to the final agent.
          			  MimePartCollection im1= email.UnknownDispositionMimeParts;
    			      //Collection containing embedded MIME parts of the message (included text parts)
    			      EmbeddedObjectCollection im2 = email.EmbeddedObjects;
    			      //Collection containing attachments of the message.
           			  AttachmentCollection attach=email.Attachments;
    		       }
                }
