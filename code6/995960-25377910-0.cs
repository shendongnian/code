     static void Main(string[] args)
        {
            List<String> list = new List<String>();
            using (StreamReader sr = new StreamReader(@"C:\Users\Tim\Desktop\example.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                    Console.WriteLine(line);
                }
            }
        }
     
