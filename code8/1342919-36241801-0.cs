     static void Main(string[] args)
                {
                    char[] Array = new char[5];
                    Console.WriteLine("Please Enter 5 Letters B/W a through j only: ");
                    string letters = "abcdefghij";
        
                    char[] read = Console.ReadLine().ToLower().ToCharArray();
        
                    //loop through array
                    for (int i = 0; i < read.Length; i++)
                    {
                        if (letters.Contains(read[i]) && !Array.Contains(read[i]))
                        {
                            Array[i] = read[i];
                        }
                        else
                        {
                            Console.WriteLine("You have entered an incorrect value");
                        }
        
                    }
        
                    Console.WriteLine("You have Entered the following Inputs: ");
                    for (int i = 0; i < Array.Length; i++)
                    {
                        Console.WriteLine(Array[i]);
                    }
                    Console.ReadKey();
                }
