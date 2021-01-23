        static void Main(string[] args)
        {
            string path = @"E:\CAT\Name.txt";
            if (!System.IO.File.Exists(path))
            {
                WriteAndOrAppendText(path, "File Created");
            }
            else if (System.IO.File.Exists(path))
            {
                WriteAndOrAppendText(path, "New Boot.");             
            }
            Console.WriteLine("Directory System - Copyright 2016 xxxxCo.");
            Console.WriteLine("What is your surname?");
            string Surname = Console.ReadLine();
            WriteAndOrAppendText(path, Surname);
            Console.WriteLine("What is your first name?");
            string fn = Console.ReadLine();
            WriteAndOrAppendText(path, fn);
            Console.WriteLine(string.Format("Hello {0}, {1}",  fn , Surname));
            Console.Read();
            Console.Clear();
            Console.WriteLine("Directory System - Copyright 2016 xxxxCo.");
            Console.WriteLine("Year?");
            Console.Read();
            string year = Console.ReadLine();
            // New file created for year and meta data
            string yearpath = @"E:\CAT\Year.txt"; ;
            if (!System.IO.File.Exists(yearpath))
            {
                using (StreamWriter tw = new StreamWriter(File.OpenWrite(yearpath)))
                {
                    tw.WriteLine("File Created!");
                    tw.Flush();
                }
            }
            else if (System.IO.File.Exists(yearpath))
            {
                WriteAndOrAppendText(yearpath, "New Boot.");
            }
            // new text writer created for year data
            var substrText = string.Format("{0} {1} {2}", year, fn.Substring(0, 1), Surname.Substring(0, 1));
            WriteAndOrAppendText(yearpath, substrText);
            Console.WriteLine("Program Complete please check the files Located in {0} , {1}", path, yearpath);
            Console.Read();
        }
        private static void WriteAndOrAppendText(string path, string strText)
        {
            if (!File.Exists(path))
            {
                StreamWriter fileStream = new StreamWriter(path, true);
                fileStream.WriteLine(strText);
                fileStream.Flush();
                fileStream.Close();
            }
            else
            {
                StreamWriter fileStream2 = new StreamWriter(path, true);
                fileStream2.WriteLine(strText);
                fileStream2.Flush();
                fileStream2.Close();
            }
        }
