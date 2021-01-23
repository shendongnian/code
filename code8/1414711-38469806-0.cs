    class Program
        {
            static void Main(string[] args)
            {
                var firstTest = "Row.3.1.1";
                var secondTest = "Qa.2.1";
    
                Console.WriteLine(BuildFromString(firstTest));
                Console.WriteLine(BuildFromString(secondTest));
    
                Console.Read();
            }
    
            public static Extract BuildFromString(string input)
            {
                return new Extract
                {
                    Code = input.Substring(0, input.LastIndexOf('.')),
                    RValue = input.Substring(input.LastIndexOf('.'))
                };
            }
    
            public class Extract
            {
                public string Code { get; set; }
                public string RValue { get; set; }
    
                public override string ToString()
                {
                    return $"Code: {Code} RValue:{RValue}";
                }
            }
        }
