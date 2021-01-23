            string filePath = @"C:\Users\Gabriel\Desktop\Test.txt";
            string filePath2 = @"C:\Users\Gabriel\Desktop\Test2.txt";
            string hash;
            string hash2;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
                using (var stream = File.OpenRead(filePath2))
                {
                    hash2 = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
            if (hash == hash2)
            {
                // Both files are the same, so you can do your stuff here
            }
