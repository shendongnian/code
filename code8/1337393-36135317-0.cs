    public static List<string> ListItems { get; set; }
    
    for(...)
    {
     for(...)
     {
      var itemList = string.Empty;
      itemList += item.ToString() + "\t";
     }
     ListItems.Add(itemList);
    }
