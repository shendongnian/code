    class Program
    {
        static void Main(string[] args)
        {
            int number;
            dynamic y;
    
            string[] answer = new string[10];
            bool result = false;
            while(!result) {
    
                Console.WriteLine("Enter the options given below 1.Add students\n 2.View all details\n 3.Sorting\n 4.Exit\n");
                int input = Convert.ToInt16(Console.ReadLine());
                switch (input)
                {
    
                    case 1:
                        Console.WriteLine("Enter the Number of Students to be added to the List");
                        number = Convert.ToInt16(Console.ReadLine());
    
                        for (int i = 0; i < number; i++)
                        {
                            answer[i] = Console.ReadLine();
                        }
                        break;
                    case 2:
                        foreach (var item in answer)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 3:
                        Array.Sort(answer);
                        foreach (var item in answer)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 4:
                        Console.WriteLine("Are you sure you want to exit");
                        Console.WriteLine("1 for Yes and N for No");
                        result = ((char)Console.Read()) == 'y';
                        break;
                }
            }
            Console.WriteLine("thank you");
            }
        }
    }
