	private IList<Coustomer> MakeCustomers(DataTable dt)
	{
		IList<Coustomer> list = new List<Coustomer>();
		foreach (DataRow row in dt.Rows)
			list.Add(MakeCustomer(row));
		return list;
	}
	
	private Customer MakeCustomer(DataRow row)
	{
		int customerId = int.Parse(row["CustomerId"].ToString());
		string CustomerName = row["CustomerName"].ToString();
		string ContactName = row["ContactName"].ToString();
		string country = row["Country"].ToString();
        //Any other fields which might be pulling from DB
		return new Customer(customerId, company, city, country);
	}
