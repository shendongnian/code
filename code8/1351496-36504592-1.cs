    List<string> varslist = new List<string>();
    
    var rowIndex = 0;
    foreach (var col in dt.Columns)
    {
    	varslist.Add(dt.Rows[rowIndex][col.ToString()].ToString());
    }
    
    foreach(var value in varslist)
    {
    	if (value == "True")
    	{
    		listBox1.Items.Add(value);
    	}
    }
