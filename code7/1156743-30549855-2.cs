    else if (a ==2)
                {
                    int[] TotalCredit = new int[15];
                    Console.WriteLine("please enter the credits");
                    int i = 0;
                    int Total = 0;
                    for (i = 0; i < 15; i++)
                    {
                        int Credit = Convert.ToInt32(Console.ReadLine());
                        Total += Credit;
        
                    }
        
                    Console.WriteLine(Total);
                }
