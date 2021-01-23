    Console.Write("Account Balance at the beginning: $");
                aBalBeginC = Console.ReadLine();
              
                //abalbeginVal = double.Parse(aBalBeginC);
                if (double.TryParse(aBalBeginC, out abalbeginVal) == false || aBalBeginC == "" || abalbeginVal <= 0)
                {
                    Console.WriteLine("Invalid data entered - no value redorded");
                    aBalBeginC = null;
                }
