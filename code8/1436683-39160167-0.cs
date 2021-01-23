                    foreach (CDO.IBodyPart attach in msg.Attachments)
                    {
                        
                        i++;
                        string filenm = "C:\\mail_automation\\attachments\\xyz" + i +".eml";
                        if (File.Exists(filenm))
                        {
                                                  
                            
                            string fn = attach.FileName;
                            attach.SaveToFile("C:\\mail_automation\\attachments\\xyz" + i + ".eml");
                            Attachment data = new Attachment(filenm);
                            mailMessage.Attachments.Add(data);                    
                            
                        }
                        else
                        {
                            File.Create(filenm);
                            string fn = attach.FileName;
                            attach.SaveToFile("C:\\mail_automation\\attachments\\xyz" + i + ".eml");
                            Attachment data = new Attachment(filenm);
                            mailMessage.Attachments.Add(data);
                        }
