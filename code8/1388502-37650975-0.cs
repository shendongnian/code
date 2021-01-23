    private static string FirstLetters(string text)
    {
        string[] words = text.Split(' ');
        return new string(words.Select(x => char.ToUpper(x[0])).ToArray());
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine(FirstLetters("This is a sentence.")); // Prints "TIAS"
        Console.WriteLine(FirstLetters("To dO someThing in HomEWork")); // Prints "TDSIH"
        Console.ReadKey();
    }
