    const int maxTries = 3;
    int currentTries = 0;
    string itemName = null;
    do
    {
        // If it's not the first try you assume that itemName won't be empty
        // so it will show the message to prompt the user for a valid item name
    	if (string.IsNullOrEmpty(itemName))
    		Console.WriteLine("Please enter the item name");
    	else
    		Console.WriteLine("Please enter an item name with valid format! You can still try to give one {0} time(s) more...", currentTries + 1);
    	itemName = Console.ReadLine();
    }
    while (++currentTries < maxTries && !Regex.IsMatch(itemName, "[a-z]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline));
    // Check how using ++ before the identifier increments currentTries 
    // before the "less than" condition is evaluated
