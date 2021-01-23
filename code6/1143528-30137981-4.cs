     class Program
        {
            private static void Main(string[] args)
            {
                int a = 0,
                b = 0;
                Console.WriteLine("Enter the numbers:");
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    // If the line consists of a sequence of digits, followed by whitespaces,
                    // followed by another sequence of digits (doesn't handle overflows)
                    if (new Regex(@"^\d+\s+\d+$").IsMatch(readLine))
                    {
                        string[] tokens = readLine.Split();
                        //Parse element 0
                        a = int.Parse(tokens[0]);
    
                        //Parse element 1
                        b = int.Parse(tokens[1]);
                    }
                    else
                    {
                        Console.WriteLine("Please enter numbers");
                    }
                }
                var c = Convert.ToInt32(Console.ReadLine());
                var d = a + b + c;
                Console.WriteLine("Sum:" + d);
            }
        }
