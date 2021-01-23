        public static bool isSQLiteDatabase(string pathToFile)
        {
            bool result = false;
            if (File.Exists(pathToFile)) {
                using (FileStream stream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byte[] header = new byte[16];
                    for (int i = 0; i < 16; i++)
                    {
                        header[i] = (byte)stream.ReadByte();
                    }
                    result = System.Text.Encoding.UTF8.GetString(header).Contains("SQLite format 3");
                    stream.Close();
                }
            }
            return result;
        }
