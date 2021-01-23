        static void Main(string[] args)
        {
            var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "userinfo.txt");
            using (var writer = new StreamWriter(file))
            {
                writer.WriteLine("Hello, World!");
            }
        }
