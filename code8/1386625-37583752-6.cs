    private void RunQuery()
    {
    	errorMsg = "";
    	q = SearchBoxItemsAll.Text;
    	try
    	{
    		OleDbCommand cmd = new OleDbCommand(q, conn);
    		OleDbDataAdapter a = new OleDbDataAdapter(cmd);
    
    		DataTable dt = new DataTable();
    
    		a.SelectCommand = cmd;
    		a.Fill(dt);
    		a.Dispose();
    	   foreach(var v in dt.Rows)
    	   {                        
    		 listBox1.Items.Add(v[0].ToString()+" "+v[1].ToString());
    	   }
    	}
    	catch (Exception ex)
    	{}
    }
	
