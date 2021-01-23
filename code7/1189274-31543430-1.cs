    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                //calls appenduserfile with a llambda expression that returns the text writer so you can write whatever you want to it.  When the llambda exits the TextWriter is flushed and the stream is disposed of automatically for you.
                AppendUserFile("example.txt", tw =>
                {
                    tw.WriteLine("I am some new text!");
                });
    
                Console.ReadKey(true);
            }
    
            private static bool AppendUserFile(string fileName, Action<TextWriter> writer)
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string filePath = Path.Combine(path, fileName);
                FileStream fs = null;
                if (File.Exists(filePath))
                    fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                else
                    fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
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
