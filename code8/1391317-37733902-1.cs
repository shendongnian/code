    class Program
    {
        static void Main(string[] args)
        {
            var settle = new Settle { Pixels = 1.5, Time = 8, Timeout = 40 };
            var parameterList = new ArrayList { 10, false, settle };
            var dither = new Dither { Method = "dither", Parameters = parameterList, Id = 42 };
    
            string temp = JsonConvert.SerializeObject(dither);
        }
    }
