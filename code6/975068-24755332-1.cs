    Parallel.ForEach(DT.Rows, row2 => {
    	try
    	{
    		bool check = (urlcheck(dataGridView.Rows[i].Cells[2].Value.ToString()));
    		if (check == true)
    			ExecuteQuery("");
    		else
    			ExecuteQuery("");
    	}
    	catch { }
    	i = i++; 
    });
