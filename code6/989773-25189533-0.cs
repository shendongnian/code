    static void Main(string[] args)
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(@"<filepath>/Program.cs")))
            {
                while (sr.Peek()>0)
                {
                    string line = sr.ReadLine();
                    if (line.Contains("Function(") 
                        && !(line.Contains("class") || line.Contains("static") || line.Contains("public")))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            Console.Read();
        }
