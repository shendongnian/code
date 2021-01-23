    public void InsertIpAdress(IPAddress myipaddress)
    {
    string cs = "Put your connection string"
    SqlConnection cn = new SqlConnection(cs);
    try
    {
        //Open connection
        cn.Open();
        //First we insert the parent(Use stored procedure provided if you want)
        SqlCommand cm = new SqlCommand("[dbo].[AddParent]", cn);
        cm.CommandType = CommandType.StoredProcedure;
        //Add parameter
        cm.Parameters.AddWithValue("@IP", myipaddress.IP);
		//Output parameter
        SqlParameter output = new SqlParameter("@Parent",SqlDbType.Int);
        output.Direction = ParameterDirection.Output;
        cm.Parameters.Add(output);
        //Execute query
        cm.ExecuteNonQuery();
		//Here we get parent id
        int parent = Convert.ToInt32(output.Value.ToString());
		
		//Then we have to add every children
		cm = new SqlCommand("INSERT INTO YourTable (IP,ParentID) VALUES (@ip,@parent);", cn);
		//Add parent as parameter 
		cm.Parameters.AddWithValue("@parent", parent);
		
        foreach(IPAddress element in myipaddress.Childs)
        {
            //Add the current child ip
            cm.Parameters.AddWithValue("@ip", element.IP);
           
            //Execute command
            cm.ExecuteNonQuery();
        }
		//Close connection
		cn.Close();
    }
    catch(Exception ex)
    {
		//You can handle exceptions here
        MessageBox.Show(ex.message);
    }
    }
