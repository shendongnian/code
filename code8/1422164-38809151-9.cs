    class MetaReader 
    {
        public static Hashtable GetData(string fname)
        {
            using (FileStream image = new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                Hashtable metadata = new Hashtable();
                byte[] imageBytes;
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                    Console.WriteLine(imageBytes.Length);
                }
                if (imageBytes.Length <= 8)
                {
                    return null;
                }
                // Skipping 8 bytes of PNG header
                int pointer = 8;
                while (pointer < imageBytes.Length)
                {
                    // read the next chunk
                    uint chunkSize = GetChunkSize(imageBytes, pointer);
                    pointer += 4;
                    string chunkName = GetChunkName(imageBytes, pointer);
                    pointer += 4;
                    // chunk data -----
                    if (chunkName.Equals("tEXt"))
                    {
                        byte[] data = new byte[chunkSize];
                        Array.Copy(imageBytes, pointer, data, 0, chunkSize);
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (byte t in data)
                        {
                            stringBuilder.Append((char)t);
                        }
                        string[] pair = stringBuilder.ToString().Split(new char[] { '\0' });
                        metadata[pair[0]] = pair[1];
                        Console.WriteLine(metadata[pair[0]]);
                    }
                    pointer += (int)chunkSize + 4;
                    if (pointer > imageBytes.Length)
                        break;
                }
                return metadata;
            }
        }
        private static uint GetChunkSize(byte[] bytes, int pos)
        {
            byte[] quad = new byte[4];
            for (int i = 0; i < 4; i++) { quad[3 - i] = bytes[pos + i]; }
            return BitConverter.ToUInt32(quad, 0);
        }
        private static string GetChunkName(byte[] bytes, int pos)
        {
            StringBuilder builder = new StringBuilder(); for (int i = 0; i < 4; i++) { builder.Append((char)bytes[pos + i]); }
            return builder.ToString();
        }
    }
 
