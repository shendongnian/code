    string filepath = @"C:\yourfile.pdf";
        string filename = Path.GetFileName(filepath);
                System.IO.Stream stream = null;
                try
                {
                    // Open the file into a stream. 
                    stream = new FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                    // Total bytes to read: 
                    long bytesToRead = stream.Length;
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    // Read the bytes from the stream in small portions. 
                    while (bytesToRead > 0)
                    {
                        // Make sure the client is still connected. 
                        if (Response.IsClientConnected)
                        {
                            // Read the data into the buffer and write into the 
                            // output stream. 
                            byte[] buffer = new Byte[10000];
                            int length = stream.Read(buffer, 0, 10000);
                            Response.OutputStream.Write(buffer, 0, length);
                            Response.Flush();
                            // We have already read some bytes.. need to read 
                            // only the remaining. 
                            bytesToRead = bytesToRead - length;
                        }
                        else
                        {
                            // Get out of the loop, if user is not connected anymore.. 
                            bytesToRead = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    // An error occurred.. 
        
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
