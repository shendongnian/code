    //Decrypt
    using DidiSoft.Pgp;
     PGPLib pgp = new PGPLib();
    
                string inputFileLocation = file Location; 
                string privateKeyLocation = @"I posted my private at this location";
                string privateKeyPassword = "Decryption Password";
                string outputFile = @"Output Location";
    
                // decrypt and obtain the original file name
                // of the decrypted file
                string originalFileName =
                  pgp.DecryptFile(inputFileLocation,
                              privateKeyLocation,
                              privateKeyPassword,
                              outputFile);
    //Move decrypted file to archive
    string path = Decrypted file Location;
                string path2 = @"Archive file location" + Path.GetFileName(file); ;
                try
                {
                    if (!File.Exists(path))
                    {
                        // This statement ensures that the file is created,
                        // but the handle is not kept.
                        using (FileStream fs = File.Create(path)) { }
                    }
    
                    // Ensure that the target does not exist.
                    if (File.Exists(path2))
                        File.Delete(path2);
    
                    // Move the file.
                    File.Move(path, path2);
    
                }
                catch (Exception e)
                {
    
                }
