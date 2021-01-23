    namespace DBCreateTags
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var reader = new StreamReader(@"T:\test.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',')[15];
    
                    }
                }
            }
    
        }
    }
