    namespace ConsoleApplication
    {
        class Program
        {
            [DllImport("kernel32.dll")]
            static extern bool CreateSymbolicLink(
            string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);
    
            enum SymbolicLink
            {
                File = 0,
                Directory = 1
            }
    
            static void Main(string[] args)
            {
                string symbolicLink = @"D:\111.mp4";
                string fileName = @"D:\111.xyz";
    
                using (var writer = File.CreateText(fileName))
                {
                    writer.WriteLine("Hello World");
                }
    
                CreateSymbolicLink(symbolicLink, fileName, SymbolicLink.File);
            }
        }
    }
