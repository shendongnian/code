    public void(List<string> sd)        
    {
        // Create a list of lists to store your lists.
        List<List<Item>> lists;
        // We're going to use this variable to refer to our
        // current, not-yet-full list (less than 10 items).
        List<Item> currentList;
        // Create the first list you'll be adding items to,
        // and add it to our list of lists.
        currentList = new List<Item>();
        lists.Add(currentList);
        foreach(var item in sd)
        {
            currentList.Add(new Item { Id = item});
            if(currentList.Count() >= 10)
            {
                // This should look familiar from above :-)
                currentList = new List<Item>();
                lists.Add(currentList);
            }
        }
    }
