    if (myReader.HasRows)
    {
    	while (myReader.Read())
    	{
    		string SetName = myReader.GetString("set_number");
    		MessageBox.Show(SetName);
    	}
    }
