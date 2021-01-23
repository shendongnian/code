        private string ReadFile(string filename)
        {
            var sb = new StringBuilder();
            if (System.IO.File.Exists(filename))
            {
                using (var f = System.IO.File.OpenRead(filename))
                {
                    var b = new byte[f.Length];
                    var len = f.Read(b, 0, b.Length);
                    while ((-1 < len) && (len == b.Length))
                    {
                        sb.Append(System.Text.Encoding.UTF8.GetString(b, 0, len));
                        len = f.Read(b, 0, b.Length);
                    }
                }
            }
            return sb.ToString();
        }
        private void WriteFile(string filename, string data)
        {
            using (var f = System.IO.File.OpenWrite(filename))
            {
                var b = System.Text.Encoding.UTF8.GetBytes(data);
                f.Write(b, 0, b.Length);
            }
        }
