    //check if any item is selected
    if (checkedListBox1.SelectedItems.Count > 0)
    {
    	//connect to database
    	string connstring = ("Server=localhost;Port=5432;User Id=postgres;Password=021393;Database=postgres;");
    	NpgsqlConnection conn = new NpgsqlConnection(connstring);
    	conn.Open();
    
    	//loop through all selected items
    	foreach (object item in checkedListBox1.CheckedItems)
    	{
    		//convert item to string
    		string checkedItem = item.ToString();
    
    		//insert item to database
    		NpgsqlCommand cmd = new NpgsqlCommand("Insert into famhistory(famid) Values (@famid)", conn);
    		cmd.Parameters.AddWithValue("@famid", checkedItem); //add item
    		cmd.ExecuteNonQuery();
    	}
    
    	//close connection
    	conn.Close();
    	MessageBox.Show("Data has been saved");
    }
