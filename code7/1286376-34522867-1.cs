                // process incoming request            
                if (!Request.Content.IsMimeMultipartContent())
                {                
                    // return error response               
                }
    
                // read the file and form data.
                ...
                await Request.Content.ReadAsMultipartAsync(provider);                           
    			...
    			
                // check if files are on the request.
                if (provider.FileStreams.Count == 0)
                {                
                    // return return error response               
                }
    
                IList<string> uploadedFiles = new List<string>();
    
                foreach (KeyValuePair<string, Stream> file in provider.FileStreams)
                {
                    // get file name and file stream
                    byte[] photo;
                    string fileName = file.Key;
                    using (Stream stream = file.Value)
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            photo = reader.ReadBytes((int)stream.Length);
                        }
                    }
    
                    // INSERT INTO DATABASE HERE (USING SqlConnection, SqlCommand...)                
                    // ...
    
                    // keep track of the filename and filelength for the response
                    uploadedFiles.Add(fileName);
                    uploadedFiles.Add(photo.Length.ToString("N0") + " bytes");
                }
                                        
                // return successful response;
