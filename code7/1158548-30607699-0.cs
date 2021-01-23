    string[] prompts = new [] { "First", "Second", "Third" };
    string tempName = null;
    IList<string> names = new List<string>(3);
    // Let's make the collection smarter so you don't need to repeat code
    foreach (var prompt in prompts)
    {
        Console.WriteLine("Please Enter The {0} Name: ", prompt);
        tempName = Console.ReadLine();
        if (!string.IsNullOrEmpty(tempName))
        {
            names.Add(tempName);
            tempName = null;
        }
    }
    names.Sort(); // will do a default string comparison for ordering
    // print the names
    
