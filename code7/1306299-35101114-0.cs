    public void DropDownListSelectEmployee_Fill()
    {
    	if (!Page.IsPostBack) 
    	{
    		DropDownListSelectEmployee.Items.Clear();
    		string q = "select username from nworksuser where _type='Employee' or _type='Admin_Employee';";
    		MySqlCommand cmd = new MySqlCommand(q, conn);
    		conn.Open();
    		string user = "";
    		MySqlDataReader rdr = cmd.ExecuteReader();
    		while (rdr.Read())
    		{
    			user = rdr.GetString("username");
    			DropDownListSelectEmployee.Items.Add(user);
    		}
    		conn.Close();
    	}
    }
