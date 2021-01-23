    class Program
    {
        private static Dictionary<int, string> employees = new Dictionary<int, string>();
        static void Main(string[] args)
        { 
            employees.Add(1, "Fred");
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var fi = new FileInfo(@"employees.bin");
            using (var binaryFile = fi.Create())
            {
                binaryFormatter.Serialize(binaryFile, employees);
                binaryFile.Flush();
            }
            Dictionary<int, string> readBack;
            using (var binaryFile = fi.OpenRead())
            {
                  readBack = (Dictionary < int, string> )binaryFormatter.Deserialize(binaryFile);
            }
            foreach (var kvp in readBack)
                Console.WriteLine($"{kvp.Key}\t{kvp.Value}");
        }
    }
