        public class BuketObjectResult
        {
            public bool Success { get; set; }
            public long Size { get; set; }
        }
        public void GetBucketObjectData()
        {
            try
            {
                BuketObjectResult res = CheckFile();
                //CHUNK  Divide in small chunks eg : 2GB file : 20MB chunks 
                int chunkSize = (int)(res.Size / CHUNK);
                if (!res.Success && (res.Size == 0 || chunkSize <= 0))
                {
                    res.Success = false;
                    return ;
                }
                string fileName = "Your file name";
                long startPostion = 0;
                long endPosition = 0;
                while (startPostion >= 0)
                {
                    byte[] chunk = new byte[chunkSize];
                    endPosition = chunkSize + startPostion;
                    if (endPosition > res.Size) //to get rest of the file
                        endPosition = res.Size;
                    GetObjectRequest request = new GetObjectRequest
                    {
                        BucketName = "your bucket name",
                        Key = "your key",
                        ByteRange = new ByteRange(startPostion, endPosition)
                    };
                    using (GetObjectResponse response = s3client.GetObject(request))
                    using (Stream responseStream = response.ResponseStream)
                    using (FileStream fileStream = File.Open(fileName, FileMode.Append))
                    {
                        int readIndex = ReadChunk(responseStream, ref chunk);
                        startPostion += readIndex;
                        if (readIndex != 0)
                        {
                            fileStream.Write(chunk, 0, readIndex);
                        }
                        if (readIndex != chunk.Length) // We didn't read a full chunk: we're done (read only rest of the bytes)
                            break;
                    }
                }
                // Verify 
                FileInfo fi = new FileInfo(fileName);
                if (fi.Length == res.Size)
                {
                    res.Success = true;
                }
              
            }
            catch (Exception e)
            {
               
            }
        }
        public BuketObjectResult CheckFile()
        {
            BuketObjectResult res = new BuketObjectResult() { Success = false};
            try
            {
                ListObjectsRequest request = new ListObjectsRequest()
                {
                    BucketName = "bucketName here ",
                    Delimiter = "/",
                    Prefix = "Location here"
                };
                ListObjectsResponse response = s3client.ListObjects(request);
                if (response.S3Objects != null && response.S3Objects.Count > 0)
                {
                    S3Object o = response.S3Objects.Where(x => x.Size != 0).FirstOrDefault();
                    if (o != null)
                    {
                        res.Success = true;
                        res.Size = o.Size;
                    }
                    
                }
                
            }
            catch (Exception e)
            {
            }
            return res;
        }
