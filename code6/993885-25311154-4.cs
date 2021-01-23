	int pageSize = 1000;
	HashSet<Guid> temp1;
    List<Guid> idsFromTable = new List<Guid>();
	var Ids = temp1.ToList();
	for(int i = 0; true; i++)
	{
    	//Cache the table locally to prevent logic running while selecting on page size
    	idsFromTable.AddRange(prodContext.Documents.Skip(pageSize * i).Take(pageSize).Select(x=> x.id));
        if(idsFromTable.Any())
        {
            //Then use the cached list instead of the datacontext
            Ids = Ids.Except(idsFromTable).ToList();
		    idsFromTable.Clear(); 
        }
        else
            break;
	}
