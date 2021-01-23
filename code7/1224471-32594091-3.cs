    internal class Program {
        private static void Main(string[] args) {
            while (true) {
                const string path = @"G:\test_dir\test.txt";
                if (File.Exists(path))
                    File.Delete(path);
                if (File.Exists(path))
                    throw new Exception("Confirmed");
                File.Create(path).Dispose();
            }
        }        
     }
