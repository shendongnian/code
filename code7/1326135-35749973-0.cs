    var studentInfoName = new List<string>();
    var studentInfoClassAndNumber = new List<int>();
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
