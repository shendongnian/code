       class Program
        {
            static void Main(string[] args)
            {
                var folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                var file = Path.Combine(folder, "testfile.txt");
    
                File.WriteAllText(file, " Test Settings");
                Console.ReadLine();
            }
        }
