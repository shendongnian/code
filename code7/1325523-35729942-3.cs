    string name; //unassigned
    int i = 0;
    while (i == 0) //will enter
    {
        Console.Write("What is your name?\n>>> ");
        name = Console.ReadLine(); //name will definitely be assigned here
        ... something else
    }
    Console.WriteLine("Good Morning, " + name); //compiler cannot "see" that the while loop will definitely be entered and name will be assigned. Therefore, "name" is unassigned
