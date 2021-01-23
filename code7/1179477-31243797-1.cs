     /// <summary>
            /// Uploads a file
            /// Documentation: https://developers.google.com/drive/v2/reference/files/insert
            /// </summary>
            /// <param name="_service">a Valid authenticated DriveService</param>
            /// <param name="_uploadFile">path to the file to upload</param>
            /// <param name="_parent">Collection of parent folders which contain this file. 
            ///                       Setting this field will put the file in all of the provided folders. root folder.</param>
            /// <returns>If upload succeeded returns the File resource of the uploaded file 
            ///          If the upload fails returns null</returns>
            public static File uploadFile(DriveService _service, string _uploadFile, string _parent) {
                
                if (System.IO.File.Exists(_uploadFile))
                {
                    File body = new File();
                    body.Title = System.IO.Path.GetFileName(_uploadFile);
                    body.Description = "File uploaded by Diamto Drive Sample";
                    body.MimeType = GetMimeType(_uploadFile);
                    body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
                                    
                    // File's content.
                    byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                    try
                    {
                        FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
                        request.Upload();
                        return request.ResponseBody;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        return null;
                    }
                }
                else {
                    Console.WriteLine("File does not exist: " + _uploadFile);
                    return null;
                }           
            
            }
