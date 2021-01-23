    static void SendFile(YourWebService webservice, string filename)
        {
            Console.WriteLine("uploading file: " + filename);
            int Offset = 0; // starting offset.
            //define the chunk size
            int ChunkSize = 65536; // 64 * 1024 kb
            //define the buffer array according to the chunksize.
            byte[] Buffer = new byte[ChunkSize];
            //opening the file for read.
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            try
            {
                long FileSize = new FileInfo(filename).Length; // File size of file being uploaded.
                // reading the file.
                fs.Position = Offset;
                int BytesRead = 0;
                string msg = "";
                while (Offset != FileSize) // continue uploading the file chunks until offset = file size.
                {
                    BytesRead = fs.Read(Buffer, 0, ChunkSize); // read the next chunk 
                    // (if it exists) into the buffer. 
                    // the while loop will terminate if there is nothing left to read
                    // check if this is the last chunk and resize the buffer as needed 
                    // to avoid sending a mostly empty buffer 
                    // (could be 10Mb of 000000000000s in a large chunk)
                    if (BytesRead != Buffer.Length)
                    {
                        ChunkSize = BytesRead;
                        byte[] TrimmedBuffer = new byte[BytesRead];
                        Array.Copy(Buffer, TrimmedBuffer, BytesRead);
                        Buffer = TrimmedBuffer; // the trimmed buffer should become the new 'buffer'
                    }
                    // send this chunk to the server. it is sent as a byte[] parameter, 
                    // but the client and server have been configured to encode byte[] using MTOM. 
                    bool ChunkAppened = webservice.UploadFile(Path.GetFileName(filename), Buffer, Offset, out msg);
                    if (!ChunkAppened)
                    {
                        Console.WriteLine("failed to upload. server return error: " + msg);
                        break;
                    }
                    // Offset is only updated AFTER a successful send of the bytes. 
                    Offset += BytesRead; // save the offset position for resume
                }
                Console.WriteLine("successfully uploaded file: " + filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to upload file: " + ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
