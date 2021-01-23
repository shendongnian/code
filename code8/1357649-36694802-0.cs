    static void skapaPerson(Person p) {
        Console.Write("Vad är personens namn? ");
        p.name = Console.ReadLine();
        Console.Write("Hur gammal är personen?");
        p.age = int.Parse(Console.ReadLine());
        Console.Write("Vad är personens hårfärg? ");
        p.haircolor = Console.ReadLine();
    }
