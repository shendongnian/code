    static Person skapaPerson()
    {
        Person pResult = new Person(); //create new Person object here
        Console.Write("Vad är personens namn? ");
        pResult.name = Console.ReadLine();
        Console.Write("Hur gammal är personen?");
        pResult.age = int.Parse(Console.ReadLine());
        Console.Write("Vad är personens hårfärg? ");
        pResult.haircolor = Console.ReadLine();
        return pResult; //return object with entered data
    }
    static void Main(string[] args)
    {
        Person Person1 = skapaPerson(); //Person 1 is the result of skapaPerson()
        Console.Write("{0} {1} {2}", Person1.name, Person1.haircolor, Person1.age);
        Console.ReadLine();
    }
