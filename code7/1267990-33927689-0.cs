    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program4
        {
            public static void Main(string[] args)
            {
                using(var stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("ConsoleApplication1.Files.TextFile1.txt"))
                using (var filestream = System.IO.File.OpenWrite("target.txt"))
                {
                    stream.CopyTo(filestream);
                    filestream.Flush();
                    filestream.Close();
                    stream.Close();
                }
            }
        }
    }
