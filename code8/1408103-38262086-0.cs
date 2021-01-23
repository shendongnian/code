    using System;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] arr = { "abc.txt", "asd.TXT", "bvc.pdf", "fgd.txt", "hss.pdf", "djhd.xml" };
                var arrp = arr.Select(file => Path.GetExtension(file).TrimStart('.').ToLower()).GroupBy(x => x, (ext, extcnt) => new
                {
                    Extension = ext,
                    count = extcnt.Count()
                });
                foreach (var v in arrp)
                {
                    Console.WriteLine("{0} files(s) with {1} Extension", v.count, v.Extension);
                    Console.ReadLine();
                }   
            }
        }
    }
