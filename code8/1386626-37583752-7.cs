    private void RunQuery()
    {
    	errorMsg = "";
    	//q = SearchBoxItemsAll.Text;
    	//Concatenate the ID and the Name in the SQL Query
    	q = "SELECT [ITEM ID] , ([ITEM ID] +' '+ [ITEM NAME]) AS [ITEM NAME] FROM ITEMS";
    	try
    	{
    		OleDbCommand cmd = new OleDbCommand(q, conn);
    		OleDbDataAdapter a = new OleDbDataAdapter(cmd);
    
    		DataTable dt = new DataTable();
    
    		a.SelectCommand = cmd;
    		a.Fill(dt);
    		a.Dispose();
    		listBox1.DisplayMember = "ITEM_NAME";
    		listBox1.ValueMember = "ITEM_ID";
    		listBox1.DataSource = dt;
    	}
    	catch (Exception ex)
    	{}
    }
