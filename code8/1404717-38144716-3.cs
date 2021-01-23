    var xml = new XmlDocument();
        xml.LoadXml(@"...");
    var random = new Random();
    var questions = xml.SelectNodes("//Question")
        .OfType<XmlElement>()
        .Select (question => new Question(question))
        .OrderBy(question => random.Next())
        .ToList();
    foreach (var question in questions)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(question.Title);
        foreach (var option in question.Options)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t{0}", option.Title);
        }
        Console.Write("Choose the right option: ");
        var answer = Console.ReadLine();
        if (question.Options.Any(option =>
            option.IsCorrect && answer.Equals(option.Title, 
                StringComparison.InvariantCultureIgnoreCase)))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("YOU HAVE CHOSEN... WISELY.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have chosen poorly!");
        }
    }
