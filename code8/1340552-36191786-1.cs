     char[] arr = new char[5];
                //User input
                Console.WriteLine("Please Enter 5 Letters only: ");
                string s = "abcdefghijklmnopqrstuvwxyz";
                for (int i = 0; i < arr.Length;)
                {
                    string sChar = Console.ReadLine().ToLower();
                    if (s.Contains(sChar) && sChar.Length == 1)
                    {
                        arr[i] = Convert.ToChar(sChar);
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a character from A-Z");
                        continue;
                    }
                }
                //display
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("You have entered the following inputs: ");
                    Console.WriteLine(arr[i]);
                }
