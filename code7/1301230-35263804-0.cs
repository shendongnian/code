    private MemoryStream SaveThumbnail(SPFile videoFile) 
            {
                MemoryStream ms; 
                try 
                {
                    //Creating Temp File Path to be used by Nreco
                   
    
                    ms = new MemoryStream();
                    SPSecurity.RunWithElevatedPrivileges(delegate() {
    
                        string destinationFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + videoFile.Name);
    
                        //Copying the content the content of the file at temp loaction from stream
                        using (FileStream fileStream = File.Create(destinationFile))
                        {
                            Stream lStream = videoFile.OpenBinaryStream();
                            byte[] contents = new byte[lStream.Length];
                            lStream.Read(contents, 0, (int)lStream.Length);
                            lStream.Close();
    
                            // Use write method to write to the file specified above
                            fileStream.Write(contents, 0, contents.Length);
                            fileStream.Close();
                        }
    
    
                        var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                        ffMpeg.GetVideoThumbnail(destinationFile, ms, 10);
    
                        System.IO.File.Delete(destinationFile);
                    });
          
                    
                }
                catch(Exception ex)
                {
                    throw ex;
                }
    
                return ms;
            }
