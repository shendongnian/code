            using (var stream = new MemoryStream())
            {
                blob.DownloadToStream(stream);
                stream.Position = 0;//resetting stream's position to 0
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader(stream))
                {
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        var result = serializer.Deserialize(jsonTextReader);
                    }
                }
            }
