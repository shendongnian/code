    string[] prompts = new [] { "First", "Second", "Third" };
    string tempName = null;
    // Create an empty collection of strings for the names,
    // starting off with a capacity equal to the number of prompts
    IList<string> names = new List<string>(prompts.Length);
    // Let's make the collection smarter so you don't need to repeat code
    foreach (string prompt in prompts)
    {
        Console.WriteLine("Please Enter The {0} Name: ", prompt);
        // collect the name
        tempName = Console.ReadLine();
        // check that something was entered before adding it to the list
        if (!string.IsNullOrEmpty(tempName))
        {
            names.Add(tempName);
        }
        
        // reset the temporary name variable; probably not necessary but...
        tempName = null;
    }
    // Sort the list
    names.Sort(); // will do a default string comparison for ordering
    // Print the names
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
    
