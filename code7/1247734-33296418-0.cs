    class Program
    {
        static void Main(string[] args)
        {
            ListFiles(@"C:\Images");
          
            Console.ReadKey();
        }
        public static void ListFiles(string path)
        {
            foreach (var file in Directory.GetFiles(path).Select(s => new FileInfo(s)))
            {
                // Implement your export logic here
                Console.WriteLine(file.FullName);
            }
            foreach (var dir in Directory.GetDirectories(path))
            {
                ListFiles(dir);
            }
        }
    }
