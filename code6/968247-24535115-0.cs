    class Program
    {
        static void Main(string[] args)
        {
            List<String> datetimeList = new List<string>();
            datetimeList.Add("05/03/2005 23:59:59.999");
            datetimeList.Add("05/3/2005 23:59:59.999");
            datetimeList.Add("5/03/2005 23:59:59.999");
            datetimeList.Add("5/3/2005 23:59:59.999");
            DateTime datetest;
            foreach (string s in datetimeList)
            {
                if (!DateTime.TryParseExact(s, "M/d/yyyy HH:mm:ss.fff", new CultureInfo("en-US"), DateTimeStyles.None, out datetest))
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    Console.WriteLine("Success");
                }
            }
            Console.Read();
        }
    }
