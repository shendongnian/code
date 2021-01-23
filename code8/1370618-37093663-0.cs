    public int return_order(string product_name)
    {
    	FileStream f1 = new FileStream("name.txt", FileMode.Open);
    	StreamReader r1 = new StreamReader(f1);
    	string name = r1.ReadLine();
    	r1.Close();
    	SqlConnection s = new SqlConnection("Data Source=(local);Initial Catalog=ShoppingOnline;Integrated Security=True");
    	s.Open();
    	SqlCommand d = new SqlCommand("Select * from Products where ProductName ='" + product_name + "'", s);
    	SqlDataReader dr;
    	dr = d.ExecuteReader();
    	int i = 0;
    	while (dr.Read())
    	{
    		i += 1;
    	}
    	dr.Close();
    	if (i == 1)
    	{
    		Form3 f = new Form3();
    		SqlCommand cmd = new SqlCommand("UPDATE Products SET Quantity = Quantity + 1 WHERE ProductName= @username ", s);
    		cmd.Parameters.AddWithValue("@username", product_name);
    		cmd.ExecuteNonQuery();
    
    		return 555; //you had no value!!!
    	}
    
    	DateTime today = DateTime.Today;
    	DateTime startdate = DateTime.UtcNow.Date;
    	FileStream f = new FileStream("bill.txt", FileMode.Open);
    	StreamReader r = new StreamReader(f);
    	string q = r.ReadToEnd();
    	string w = "";
    
    	if (!q.Contains(product_name))
    		return 2; //wrong
    	
    	while (r.ReadLine() != "EOO")
    	{
    		f.Position = 0;
    		r.DiscardBufferedData();
    		string enddate = r.ReadLine();
    		f.Position = 0;
    		r.DiscardBufferedData();
    		while (r.Peek() != -1)
    		{
    			DateTime dt = Convert.ToDateTime(enddate);
    			DateTime dt2 = Convert.ToDateTime(startdate);
    
    			if ((dt2 - dt.Date).TotalDays >= 14)
    				return -1; //late
    
    			string temp = r.ReadLine();
    			if (temp == "Customer Name: " + name + "")
    			{
    				string record = r.ReadLine();
    				string[] fields = record.Split('@');
    				if (fields[0] == product_name)
    				{
    					w = fields[1];
    					SqlCommand cmd = new SqlCommand("insert into Products(ProductName,Price,Quantity) values('" + product_name + "','" + w + "','" + 1 + "')", s);
    					cmd.ExecuteNonQuery();
    					return 1;
    				}
    			}
    		}
    		r.Close();
    	}
    	return 555; //some default value (you had no value!!!)
    }
