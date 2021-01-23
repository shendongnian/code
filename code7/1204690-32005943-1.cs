    public class Program
    {
        static void Main(string[] args)
        {
            var z = ZipFile.OpenRead(@"C:\directory\anyfile.zip");
            foreach (ZipArchiveEntry f in z.Entries)
            {
               var yourhash = GetMD5HashFromFile(f.Open());
            }
            
        }
        public static string GetMD5HashFromFile(Stream stream)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var buffer = md5.ComputeHash(stream);
                var sb = new StringBuilder();
                for (int i = 0; i < buffer.Length; i++)
                {
                    sb.Append(buffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
