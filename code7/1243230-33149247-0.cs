    static void Main(string[] args)
    {
        string nameString = "Sean Pen / 212321\n Chris Brown / 578,4\n Sandy Sanders / 879757";
    
        var names = ExtractNames(nameString);
        foreach (var name in names)
        {
            Console.WriteLine("-" + name + "-");
        }   
    }
    
    static List<string> ExtractNames(string input)
    {
        return input.Split('\n').Select(RemoveNumbers).ToList();
    }
    
    static string RemoveNumbers(string input)
    {
        return new string(input.Where(c => char.IsLetter(c) || char.IsSeparator(c)).ToArray()).Trim();
    }
