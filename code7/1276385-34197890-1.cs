    [HttpPost]
    public ActionResult Enter(FormCollection form)
    {
    	var data = new List<List<string>>();
    	var rows = int.Parse(form["rows"]);
    	var columns = int.Parse(form["columns"]);
    
    	for (var r = 0; r < rows; r++)
    	{
    		var rowData = new List<string>();
    
    		for (var c = 0; c < columns; c++)
    		{
    			rowData.Add(form[string.Format("name{0}{1}", r, c)]);
    		}
    
    		data.Add(rowData);
    	}
    
        return View(data);
    }
