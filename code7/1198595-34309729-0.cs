            public static void ReadFromFile()  
            {
                using(StreamReader sr =File.OpenText(@"D:\new.txt"))
                {
                    string line=null;
                    while ((line=sr.ReadLine())!= null)
                    {
                     //   line = sr.ReadLine;
                        using (StreamWriter sw = File.AppendText(@"D:\output.txt"))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
