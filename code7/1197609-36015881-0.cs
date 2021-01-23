     foreach (var msg in messages)
                 
                            {
                                 foreach (var attachment in msg.Attachments)
                                {
    
                                    byte[] allBytes = new byte[attachment.ContentStream.Length];
                                    int bytesRead = attachment.ContentStream.Read(allBytes, 0, (int)attachment.ContentStream.Length);
    
                                    string destinationFile = @"C:\Download\" + attachment.Name;
    
                                    BinaryWriter writer = new BinaryWriter(new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
                                    writer.Write(allBytes);
                                    writer.Close();
                                }
                              
                    }
