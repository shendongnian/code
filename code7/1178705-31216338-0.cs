     if (File.Exists(@"C:\test files\log.txt"))
                        {
                            string dump = @"C:\test files\log.txt";
                            using(StreamWriter Streamwriter = new StreamWriter(dump))
                            {
                            Console.WriteLine("An unknown exception was detected and an error log has been dumped at {0}!", dump);
                            Streamwriter.WriteLine(ex.Message);
                            Streamwriter.WriteLine(ex.StackTrace);
                            Streamwriter.Close();
                         }
                        }
