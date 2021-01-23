    using System;
    using System.IO;
    using System.IO.StreamReader;
    
    class Perfect
    {
        static void Main()
        {
            const string filename = @"marks.cvs";
            using (var sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
