    foreach (var item in listA)
    {
    	item.NameB = ListB.Where(w => w.Id == item.Id).FirstOrDefault();
    	List<Item> cList = new List<Item>();
    	foreach (var c in ListC.Where(w => w.ID == item.ID))
    	{
    		cList.Add(c);
    	}
    	item.NameC=cList;
    }
