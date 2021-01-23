     System.IO.BinaryReader r = new System.IO.BinaryReader(FileUpload1.PostedFile.InputStream);
                                    string fileclass = "";
                                    byte buffer;
                                    try
                                    {
                                        buffer = r.ReadByte();
                                        fileclass = buffer.ToString();
                                        buffer = r.ReadByte();
                                        fileclass += buffer.ToString();
                                    }
                                    catch
                                    {
                                    }
                                    r.Close();
                                    if (fileclass != "3780" || fileclass != "255216" || fileclass != "13780")    /*Header codes (3780-PDF);(255216-JPG,JPEG);(13780-PNG)*/
                                      {
                                        /*Your code goes here(things to do with the file uploaded)*/
                                      }
