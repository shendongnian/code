        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length != 0)
                {
                    string line = null;
                    string targetStart = "@{";
                    string targetEnd = "}";
                    string fileName = args[0];
    
                    using (var reader = new StreamReader(fileName))
                    {
                        line = reader.ReadLine();
                        if (line.Contains(targetStart))
                        {
                            while (reader.ReadLine() != targetEnd)
                            {
                                var readLine = reader.ReadLine();
                                if (readLine != null) Console.WriteLine(readLine.ToString());
                            }
                        }
                        Console.Read();
                    }
                }
    
            }
        }
    }
