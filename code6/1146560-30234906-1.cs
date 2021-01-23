    using System;
    using System.IO;
    namespace createIndex_php
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = string.Empty;
                try
                {
                    if (File.Exists(args[0])) // right clicked on a file in explorer
                    {
                        path = Path.GetDirectoryName(args[0]);
                    }
                    else
                    {
                        path = args[0];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format(@"Error while creating ""index.php"": {0}", ex.Message));
                    Console.ReadKey();
                }
                if (path != string.Empty)
                {
                    path = Path.Combine(path, "index.php");
                    try
                    {
                        File.Create(path);
                        Console.WriteLine(@"""index.php"" created!");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format(@"Error while creating ""index.php"": {0}", ex.Message));
                        Console.ReadKey();
                    }
                }
            }
        }
    }
