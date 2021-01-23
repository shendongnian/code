        public static byte[] Decompress(byte[] gzip) {
            using (var stream = new Ionic.Zlib.ZlibStream(new MemoryStream(gzip), Ionic.Zlib.CompressionMode.Decompress)) {
                const int size = 1024;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream()) {
                    int count = 0;
                    do {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0) {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
