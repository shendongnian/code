    var myList = new List<myClass>()
    {
        new myClass() { Name = "ABC", AdditionalData = "1", ActivityTime = DateTime.Now },
        new myClass() { Name = "ABC2", AdditionalData = "2", ActivityTime = DateTime.Now },
        new myClass() { Name = "ABC3", AdditionalData = "3", ActivityTime = DateTime.Now.AddSeconds(6) },
        new myClass() { Name = "ABC4", AdditionalData = "3", ActivityTime = DateTime.Now.AddSeconds(11) },
        new myClass() { Name = "ABC4", AdditionalData = "3", ActivityTime = DateTime.Now.AddSeconds(12) }
    };
    
    var results = new List<List<myClass>>();
    
    myClass previousItem = null;
    List<myClass> currentList = new List<myClass>();
    foreach (var item in myList)
    {
        if (previousItem == null || (item.ActivityTime - previousItem.ActivityTime).TotalSeconds >= 5)
        {
            currentList = new List<myClass>();
            results.Add(currentList);
        }
    
        currentList.Add(item);
        previousItem = item;
    }
