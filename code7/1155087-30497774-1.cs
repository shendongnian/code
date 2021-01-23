    public static void Main()
    {
        string[] groceryItemsArray = System.IO.File.ReadAllLines(@"C:\C\groceries.txt");
        // now split each line content with comma. It'll return you an array (sub-array)
        foreach (var line in groceryItemsArray)
        {
            string[] itemsInLine = line.Split(',');
           // Do whatevery you want to do with this.
           // e.g. for 1st line itemsInLine array will contains 4 items 
           // "regular","bread","2.00", "2"
        }
    }
