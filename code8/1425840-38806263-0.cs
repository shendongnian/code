    List<String> displayNames = new List<string>();
    // grab the cells that contain the display names you want to verify are sorted
    IReadOnlyList<IWebElement> cells = Driver.FindElements(locator);
    // loop through the cells and assign the display names into the ArrayList
    foreach (IWebElement cell in cells)
    {
        displayNames.Add(cell.Text);
    }
    // make a copy of the displayNames array
    List<String> displayNamesSorted =  new List<string>(displayNames);
    displayNamesSorted.Sort();
    Console.WriteLine(displayNames.SequenceEqual(displayNamesSorted));
