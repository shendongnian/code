    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppendUserFile("example.txt", tw =>
                {
                    tw.WriteLine("I am some text!");
                });
    
                Console.ReadKey(true);
            }
    
            private static bool AppendUserFile(string fileName, Action<TextWriter> writer)
            {
                string homeDrive = Environment.GetEnvironmentVariable("homedrive");
                string homePath = Environment.GetEnvironmentVariable("homepath");
                string myDocuments = "\\My Documents\\";
                string baseFolder = string.Concat(homeDrive, homePath, myDocuments);
                if (!Directory.Exists(baseFolder))
                    Directory.CreateDirectory(baseFolder);
                string path = string.Concat(baseFolder, fileName);
                FileStream fs = null;
                if (File.Exists(path))
                    fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read);
                else
                    fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);
                TextWriter tw = (TextWriter)new StreamWriter(fs);
                try
                {
                    writer(tw);
                    tw.Flush();
                    return true;
                }
                catch {
                    return false;
                }
                finally
                {
                    if (fs != null)
                        fs.Dispose();
                    fs = null;                
                }
            }
        }
    }
