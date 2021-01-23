    class Program
    {
        static void Main()
        {
    
           var ints =  ConvertType<int>("33");
           var bools = ConvertType<bool>("false");
           var decimals = ConvertType<decimal>("1.33m"); // exception here
           Console.WriteLine(ints);
           Console.WriteLine(bools);
            Console.WriteLine(decimals);
    
            Console.ReadLine();
        }
    
        public static T ConvertType<T>(string input)
        {
            T result =  default(T);
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    result =  (T)converter.ConvertFromString(input);
                }
                catch 
                {
                    // add you exception handling
                }
            }
            return result;
        }
    }
