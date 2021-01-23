    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace MyConsole
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var path = Environment.CurrentDirectory;
                var fromDate = DateTime.Now.AddDays(-1);
                var toDate = DateTime.Now;
    
                var files = MyClass.GetModifiedFiles(path, fromDate, toDate);
    
                //System.Linq.Enumerable+WhereArrayIterator`1[System.IO.FileInfo]
                Console.WriteLine(files);
    
                //System.Collections.Generic.List`1[System.IO.FileInfo]
                Console.WriteLine(files.ToList());
    
                //MyConsole.exe
                //MyConsole.exe.config
                //MyConsole.pdb
                //MyConsole.vshost.exe
                //MyConsole.vshost.exe.config
                foreach (var file in files)
                {
                    Console.WriteLine(file.Name);
                }
    
                //MyConsole.exe
                //MyConsole.exe.config
                //MyConsole.pdb
                //MyConsole.vshost.exe
                //MyConsole.vshost.exe.config    
                var myClass = new MyClass();
                myClass.FindModifiedFiles(path, fromDate, toDate);
                Console.WriteLine(myClass); // .ToString implicitly called
    
                Console.ReadLine();
            }
        }
    
        internal class MyClass
        {
            private IEnumerable<FileInfo> _modifiedFiles;
    
            public void FindModifiedFiles(string path, DateTime fromDate, DateTime toDate)
            {
                _modifiedFiles = GetModifiedFiles(path, fromDate, toDate);
            }
    
            /* overriding default implemenation of ToString */
    
            /// <summary>Returns a string that represents the current object.</summary>
            /// <returns>A string that represents the current object.</returns>
            /// <filterpriority>2</filterpriority>
            public override string ToString()
            {
                return string.Join(Environment.NewLine, _modifiedFiles.Select(s => s.Name));
            }
    
            public static IEnumerable<FileInfo> GetModifiedFiles(string path, DateTime fromDate, DateTime toDate)
            {
                if (path == null) throw new ArgumentNullException(nameof(path));
                var directory = new DirectoryInfo(path);
                var files = directory.GetFiles()
                    .Where(file => file.LastWriteTime >= fromDate && file.LastWriteTime <= toDate);
                return files;
            }
        }
    }
