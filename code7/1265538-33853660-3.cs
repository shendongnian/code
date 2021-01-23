    class Program
        {
            static void Main(string[] args)
            {
                EnterNumber();
                Console.ReadKey();
    
                bool doEnd = false;
    
                while (!doEnd)
                {
                    Console.WriteLine("");
                    Console.WriteLine("1.Assign New Set of Integers");
                    Console.WriteLine("2.Exit");
                    ConsoleKeyInfo info = Console.ReadKey();
                    int val;
                    if (!int.TryParse(info.KeyChar.ToString(), out val))
                    {
                        // Error handling...
                    }
                    switch (val)
                    {
                        case 1: EnterNumber();
                            break;
                        case 2:
                            doEnd = true;
                            break;
                    }
                }
    
            }
    
            private static void EnterNumber()
            {
                string input;
                int userNumber;
    
                Console.Write("Enter a number: ");
                input = Console.ReadLine();
                userNumber = int.Parse(input);
    
                Console.WriteLine("\n" + "Number Occurrences");
                int[] number = new int[10];
                int[] numberTwo = new int[userNumber];
                Random randNum = new Random();
    
                for (int counter = 0; counter < userNumber; counter++)
                {
                    numberTwo[counter] = randNum.Next(10);
                    if (numberTwo[counter] == 0)
                    {
                        number[0]++;
                    }
                    if (numberTwo[counter] == 1)
                    {
                        number[1]++;
                    }
                    if (numberTwo[counter] == 2)
                    {
                        number[2]++;
                    }
                    if (numberTwo[counter] == 3)
                    {
                        number[3]++;
                    }
                    if (numberTwo[counter] == 4)
                    {
                        number[4]++;
                    }
                    if (numberTwo[counter] == 5)
                    {
                        number[5]++;
                    }
                    if (numberTwo[counter] == 6)
                    {
                        number[6]++;
                    }
                    if (numberTwo[counter] == 7)
                    {
                        number[7]++;
                    }
                    if (numberTwo[counter] == 8)
                    {
                        number[8]++;
                    }
                    if (numberTwo[counter] == 9)
                    {
                        number[9]++;
                    }
                }
                for (int numberThree = 0; numberThree <= 9; numberThree++)
                {
                    Console.WriteLine(numberThree + "\t" + number[numberThree]);
                }
            }
        }
