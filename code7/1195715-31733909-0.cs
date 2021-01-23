        static void Main(string[] args)
        {
            string str = "2015-07-29T19:55:10.994sdfsdf";
            Console.WriteLine(IsvalidDateTime(str));
            
        }
        static bool IsvalidDateTime(string date)
        {
            DateTime dt;
            return DateTime.TryParse(date, out dt);
        }
