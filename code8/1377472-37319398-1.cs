    read = new readMail(
                                "some.mail.server",
                                port,
                                true,
                                this.username,
                                this.password
                            );
                    ...
    
                    var emailList = read.GetAllMails(this.folderEmail);
                    Mailbox bbb = read.client.SelectMailbox(this.folderEmail);
                    int[] unseen = bbb.Search("UNSEEN");
                    foreach (Message email in emailList)
                    {
                        byte[] array0 = Encoding.ASCII.GetBytes(email.BodyText.Text);
                        EmbeddedObjectCollection immagini_mail = email.EmbeddedObjects;
                        MimePartCollection immagini_mail2 = email.UnknownDispositionMimeParts;
                        contenuto += email.BodyHtml.Text.ToString();
                        string contenuto2 = email.BodyText.Text.ToString();
                        byte[] array = Encoding.ASCII.GetBytes(contenuto);
                        byte[] array2 = Encoding.ASCII.GetBytes(contenuto);
                        if (immagini_mail.Count > 0)
                        {
                          //do something with images
    
                        }
                    }
