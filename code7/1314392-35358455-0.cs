            var buffer = new byte[1024 * 1024];
            using (var gz = new GZipStream(new FileStream("freebase-rdf-latest.gz", FileMode.Open), CompressionMode.Decompress))            
            {
                var bytesRead = 0;
                while (bytesRead < buffer.Length)
                {
                    bytesRead = gz.Read(buffer, 0, buffer.Length);
                    Console.WriteLine(bytesRead);
                }
            }
