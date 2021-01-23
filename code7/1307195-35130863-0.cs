    public void DoIt(List<MyObject> theList)
    {
        List<MyObject> items_to_remove = new List<MyObject>();
        List<MyObject> items_to_add = new List<MyObject>();
        for (int i = 0; i < theList.Count; i++)
        {
            if (someCircunstances)
                items_to_remove.Add(....); //Remove some existing item
            else
                items_to_add.Add(....); //Add a new item
        }
        if(items_to_remove.Count > 0)
            items_to_remove.ForEach(x => theList.Remove(x));
        if (items_to_add.Count > 0)
        {
            DoIt(items_to_add); //Recursively process new objects 
            theList.AddRange(items_to_add);
        }
    }
