        private bool CompareStreamContents(Stream resourceStream, Stream fileStream)
        {
            var sha = new SHA256CryptoServiceProvider();
            var hash1 = Convert.ToBase64String(sha.ComputeHash(ReadToEnd(resourceStream)));
            var hash2 = Convert.ToBase64String(sha.ComputeHash(ReadToEnd(fileStream)));
            return hash1 == hash2;
        }
        private byte[] ReadToEnd(Stream stream)
        {
            var continueRead = true;
            var buffer = new byte[0x10000];
            var ms = new MemoryStream();
            while (continueRead)
            {
                var size = stream.Read((byte[])buffer, 0, buffer.Length);
                if (size > 0)
                {
                    ms.Write(buffer, 0, size);
                }
                else
                {
                    continueRead = false;
                }
            }
            return ms.ToArray();
        }
