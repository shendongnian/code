    string itemName = null;
    do
    {
        // If it's not the first try you assume that itemName won't be empty
        // so it will show the message to prompt the user for a valid item name
    	if (string.IsNullOrEmpty(itemName))
    		Console.WriteLine("Please enter the item name");
    	else
    		Console.WriteLine("Please enter an item name with valid format!");
    	itemName = Console.ReadLine();
    }
    while (!Regex.IsMatch(itemName, "[a-z]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline));
    // Now that you know the itemName is valid, you can set the whole property:
    item1.itemname = itemName;
