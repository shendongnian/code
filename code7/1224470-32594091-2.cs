    internal class Program {
        private static void Main(string[] args) {
            const string path = "G:\\test_dir";
            while (true) {         
                if (Directory.Exists(path))
                    Directory.Delete(path);       
                Directory.CreateDirectory(path);   
                if (!Directory.Exists(path))
                    throw new Exception("Confirmed");                 
            }            
        }        
    }
