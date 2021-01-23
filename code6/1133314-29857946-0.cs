        static void Main(string[] args)
        {
            Console.WriteLine("Make With Palindrome");
            Console.WriteLine("Enter a positive number:");
            string input = Console.ReadLine();
            long receivedNumber;
            bool validnumber = Int64.TryParse(input, out receivedNumber);
            if (validnumber && receivedNumber>0)
            {
                long reversedAcceptablenumber;
                int counter = 0;
                while (true)
                {
                    char[] arr = input.ToCharArray();
                    Array.Reverse(arr);
                    Int64.TryParse(new string(arr),out reversedAcceptablenumber);
                    
                    if (receivedNumber==reversedAcceptablenumber)
                    {
                        break;
                    }
                    receivedNumber += reversedAcceptablenumber;
                    input = receivedNumber.ToString();
                    counter++;
                }
                Console.WriteLine("{0} steps and palindrome={1}",counter,reversedAcceptablenumber);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid character");
                Console.ReadLine();
            }
        }
