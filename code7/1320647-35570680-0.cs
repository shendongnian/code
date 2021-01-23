    static void Main(string[] args)
        {
            FileInfo fileInfo = new FileInfo((@"C:\Muckabout\StringCounter\test.txt"));
            using (var stream = new StreamReader(fileInfo.FullName))
            {
                var firstLine = stream.ReadLine(); // Read the first line.
                Console.WriteLine("First line read. This is roughly " + (firstLine.Length * 2.0) / fileInfo.Length * 100 + " per cent of the file.");
            }
            Console.ReadKey();
        }
