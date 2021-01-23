    ObjList list = ExtList.FirstOrDefault(x => x.Id == newlist.Id);
    
    if (list!= null)
    {
    	var position = ExtList.IndexOf(list);
    	ExtList.Insert(position, newlist);
    	ExtList.Remove(list);
    }
