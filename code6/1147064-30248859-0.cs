    SortedList<string, systemuser> Users = new SortedList<string, systemuser>();
    Users.Add("username1",customobject);
    Users.Add("username2",customobject);
    Users.Add("username3",customobject);
    
    var index = Users.IndexOfKey("username1");
    var nextItemKey = s.Keys[(index + 1) % Users.Count()];
    var nextItemValue = Users.IndexOfKey(nextItemKey);
