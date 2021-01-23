    int[] Original;
    //Load File
    private void mnuLoad_Click_1(object sender, EventArgs e)
    {
    	//code to load the numbers from a file
    	var fd = new OpenFileDialog();
    
    	//open the file dialog and check if a file was selected
    	if (fd.ShowDialog() == DialogResult.OK)
    	{
    		var file = fd.FileName;
    
    		try
    		{
    			var ints = new List<int>();
    		    var data = File.ReadAllLines(file);
    
    		   	foreach (var datum in data)
    		   	{
    				int value;
    				if (Int32.TryParse(datum, out value))
    				{
    					ints.Add(value);
    				}
    		   	}
    
    		   	Original = ints.ToArray();
    
    		}
    		catch (IOException)
    		{
    			// blah, error
    		}
    	}
    }
