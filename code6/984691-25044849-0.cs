    List<string> list = new List<string>(); 
    
    list.Add("Gandarez");
    list.Add("Carlos");
    
    var search = list.FirstOrDefault(l => l == "Carlos");
    
    if (search != null)
    {
        var index = list.IndexOf("Carlos");
        list.RemoveAt(index);
        list.Insert(index, "Test");
    }
