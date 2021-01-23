    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Sending in: \n43443333222211111117");
                var largeBrokenNumber = JsonConvert.DeserializeObject<Foo>("{\"Blah\": 43443333222211111117 }");
                Console.WriteLine(largeBrokenNumber.Blah);
    
                Console.WriteLine();
    
                Console.WriteLine("Sending in: \n53443333222211111117");
                var largeOddWorkingNumber = JsonConvert.DeserializeObject<Foo>("{\"Blah\": 53443333222211111117 }");
                Console.WriteLine(largeOddWorkingNumber.Blah);
            }
        }
    
        public class Foo
        {
            public string Blah { get; set; }
        }
