    ```cs
        public static void ComputeMD5Hash(object filePath)
        {
            using (var stream = new FileStream((string)filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var md5gen = new MD5CryptoServiceProvider())
                {
                    md5gen.ComputeHash(stream);
                    Program.MD5Hash = BitConverter.ToString(md5gen.Hash).Replace("-", "").ToLower();
                }
            }
        }
    ```
