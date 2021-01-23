        public static void WriteAllBase64Text(string path, string text)
        {
            File.WriteAllText(path, Convert.ToBase64String(Encoding.UTF8.GetBytes(text)));
        }
        public static string ReadAllBase64Text(string path)
        {
            var bytes=File.ReadAllText(path);
            var encoded = System.Convert.FromBase64String(bytes);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }
