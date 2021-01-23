    string searchText = "text";//Hardcoded for the sake of example
    List<string> items = new List<string>();
    items.Add("text 1");
    items.Add("hello");
    items.Add("text 2");
    foreach(string item in items)
    {
        if(item.StartsWith(searchText))
        {
            System.Diagnostics.Debugger.Break();//Do something...
        }
    }
