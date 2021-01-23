        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream stream = new MemoryStream(byteArrayIn))
                                                                      ^
            {
                return Image.FromStream(stream);
            }
        }
