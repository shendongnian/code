    class Program
        {
            private static int[] a = new int[10]; //global int!!!
            static void Main(string[] args)
            {
                for (int place = 0; place < a.Length; place++)
                {
                    Console.WriteLine("Please enter a number to be stored in element " + place + " : ");
                    var input = Console.ReadLine();
                    Int32.TryParse(input, out a[place]);
                }
    
            }
        }
