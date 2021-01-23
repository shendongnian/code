    string name = (Console.ReadLine());
    Console.WriteLine("Is " + name + " ok?");
    Console.WriteLine("\n(Y)es\n(N)o");
    var ansys = Console.ReadKey();
    if (ansys.KeyChar == 'y' || ansys.KeyChar == 'Y')
    {
        //Handle yes case
    }
    if (ansys.KeyChar == 'n' || ansys.KeyChar == 'N')
    {
        //Handle no case
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Enter letters only");
    }
