    List<string> coll = new List<string>() { "1", "2", "3", "4", "5" };
    for (int i = 0; i < coll.Count; i++)
    { 
       coll[i] = "";       
       coll.Add(i.ToString());
       coll.Remove("1");
    }
