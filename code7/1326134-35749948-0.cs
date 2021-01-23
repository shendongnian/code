    static void Main(string[] args)
        {
            DrawStarLine();
            DrawTitle();
            DrawMenu();
            List<int> studentInfoClassAndNumber = new List<int>();
            List<string> studentInfoName = new List<string>();
            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
                Console.WriteLine("Enter information about a student");
                
                Console.Write("Name: ");
                studentInfoName.Add(Console.ReadLine());
                Console.Write("Middle name: ");
                studentInfoName.Add(Console.ReadLine());
                Console.Write("Last name: ");
                studentInfoName.Add(Console.ReadLine());
                
                Console.Write("Class ");
                studentInfoClassAndNumber.Add(int.Parse(Console.ReadLine()));
                Console.Write("Number ");
                studentInfoClassAndNumber.Add(int.Parse(Console.ReadLine()));
            }
            else if (answer == 2)
            {
                Console.WriteLine("Enter the name of the student that you want to retrieve information about");
              ?????????????????????????????????????????????????
            }
            else
            {
                ErrorMessage();
            }
            Console.ReadKey();
        }
