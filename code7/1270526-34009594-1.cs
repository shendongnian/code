    {
        List<List<int>> intList = new List<int>(); // This creates a two dimensional list.
        System.IO.StreamReader inputFile = new System.IO.StreamReader(DataFile);
        string line = inputFile:ReadLine();
        while (line != null) // Iterate over the lines in the document.
        {
            intList.Add( // Adding a new row to the list.
                line.Split(',').Select(int.Parse).ToList()
                // This separates the line by commas, and turns it into a list of integers.
            );
            line = inputFile:ReadLine(); // Move to the next row.
        }
    }
