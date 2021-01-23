    string input = Console.ReadLine();
    var groupedLettersOrdered = input.GroupBy(x => x, (character, charCollection) =>
        new {Character = character, Count = charCollection.Count()})
        .OrderBy(x => x.Character);
    foreach(var letterGroup in groupedLettersOrdered)
        Console.WriteLine("Character {0}, Count: {1}", letterGroup.Character, letterGroup.Count);
