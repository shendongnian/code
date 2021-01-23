    string query ="";
    if (model.source != null)
        query +="source like '" + model.source + "%'";
    
    if (model.destination != null)
    {
    	if(query!=string.Empty)
    		query+=" and ";
         query +="destination like '" + model.destination + "%'";
    }
    if(query!=string.Empty)
    {
    	var result=_filterFly.Select(query);
    	if (result.Any()) 
    		_filterFly = result.CopyToDataTable(); 
    	else 
    		_filterFly.Clear();
    }
