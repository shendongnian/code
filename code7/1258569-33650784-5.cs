    List<string> coll = new List<string>() { "1", "2", "3", "4", "5" };
    for (int i = coll.Count-1; i>=0 ; i--)
    { 
       /* You can assign value to an item:
        coll[i] = "";       
       You can add an item to the collection:
       coll.Add(i.ToString());*/
       coll.RemoveAt(i);
       //or coll.Remove("your string value to delete");
    }
