    Contents = stream =>
            {
                using (var gzip = new GZipStream(stream, CompressionMode.Compress))
                using (var streamWriter = new StreamWriter(gzip))
                {
                    for (int i = 0; i < 5;i++ )
                    {
                        string txt = "Hello";
                        streamWriter.WriteLine(txt);
                        streamWriter.Flush();
                        Thread.Sleep(1000);
                    }
                }
            };
