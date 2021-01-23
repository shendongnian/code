    string pathfile = @"C:\Users\Public\Documents\Filepath.txt";
    
                    if (File.Exists(pathfile))
                    {
                        
                        File.Delete(pathfile);
                        
    
                    }
                    if (!File.Exists(pathfile))
                    {
                        
    
                        using (FileStream fs = File.Create(pathfile))
                      
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes("your text to be written to the file place here");
                          
                            
                            FileSecurity fsec = File.GetAccessControl(pathfile);
                            fsec.AddAccessRule(new FileSystemAccessRule("Everyone",
                            FileSystemRights.WriteData, AccessControlType.Deny));
                            File.SetAccessControl(pathfile, fsec);
    
                        }
    
    
                        }
