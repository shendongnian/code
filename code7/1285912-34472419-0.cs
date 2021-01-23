        string name;
        Console.Write("What is your name?: ");
        name = Console.ReadLine();
        Console.WriteLine("Hello " + name);
        Console.ReadLine();
        Console.Write("How old are you?: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("So you're name is " + name + " and you are " + age + " years old?");
        Console.ReadLine();
        Console.Write("Tell me, yes or no?: ");
        string answer = Console.ReadLine();
        if (answer == "no" || answer == "No")
        { 
           Console.Write("Ahh okay, what was your name again?: ");
           name  = Console.ReadLine();
        }
