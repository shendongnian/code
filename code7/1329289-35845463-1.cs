     class Program
        {
            static void Main()
            {
    
                var ints = (int)ConvertType(typeof(int),"33"); 
                var bools = (bool)ConvertType(typeof(bool), "true");   
    
                Console.WriteLine(bools);
                Console.WriteLine(ints);
    
                Console.ReadLine();
            }
           
            public static object ConvertType(Type type, string input)
            {
                object result = default(object);
                var converter = TypeDescriptor.GetConverter(type);
                if (converter != null)
                {
                    try
                    {
                        result = converter.ConvertFromString(input);
                    }
                    catch
                    {
                        // add you exception handling
                    }
                }
                return  result;
            }
        }
