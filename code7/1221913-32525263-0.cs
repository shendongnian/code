    using System;
    using System.IO;
    using System.Linq;
    class Program {
        static string FileSizeDisplay(FileInfo f) {
            int maximumfilessize= 1;
            const int MB = 1024 * 1024;
            if (f.Length <= maximumfilessize * MB) {
                return Math.Round(((double)f.Length / MB), 1).ToString() + " MB";
            }
            return ((int)f.Length / MB) + " MB";
        }
        static void Main(string[] args) {
            var files = new DirectoryInfo(@"d:\")
                .GetFiles("*.avi")
                .Select(f => Path.GetFileNameWithoutExtension(f.Name) + " " + FileSizeDisplay(f))
                .ToList();
        }
    }
