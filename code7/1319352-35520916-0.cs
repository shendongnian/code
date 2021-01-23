    while (true)
    {
        Console.WriteLine("Bitte gib ein Wort ein das es zu erraten gilt. Sag deinem Mitspieler er soll weg sehen: ");
       string word = Console.ReadLine().ToUpper();
       if (word.All(c => char.IsLetter(c))
           return word;
       Console.WriteLine("Also bitte, nur Buchstaben sind hier erlaubt!");
    }
