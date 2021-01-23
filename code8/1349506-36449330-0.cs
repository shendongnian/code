    using System;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\testfolder";
            string[] files = Directory.GetFiles(filePath, "009*.doc");
    
            // Creates a string with all the elements of the array, separated by ", "
            string matchingFiles = string.Join(", ", files);
    
            Console.WriteLine(matchingFiles);
            // Since there is only one matching file, the above line only prints:
            // C:\testfolder\009028447_ test2.doc
        }
    }
