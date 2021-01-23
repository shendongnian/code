            var chunk = Upload.CreateChunkedUploader(); //Create an instance of the ChunkedUploader class (I believe this is the only way to get this object)
            
            using(FileStream fs = File.OpenRead(VideoPath))
            {
                chunk.Init("video/mp4", (int)fs.Length); //Important! When initialized correctly, your "chunk" object will now have a type long "MediaId"
                byte[] buffer = new byte[4900000]; //Your chunk MUST be 5MB or less or else the Append function will fail silently.
                int bytesRead = 0;
    
                while((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    byte[] copy = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, copy, 0, bytesRead);
                    chunk.Append(copy, chunk.NextSegmentIndex); //The library says the NextSegment Parameter is optional, however I wasn't able to get it to work if I left it out. 
                }
            }
    
            var video = chunk.Complete(); //This tells the API that we are done uploading.
            Tweet.PublishTweet("Tweet text:", new PublishTweetOptionalParameters()
            {
                Medias = new List<IMedia>() { video }
            });
