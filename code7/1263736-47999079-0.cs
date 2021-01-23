    public IList<Order> GetOrders(string CustomerID)
	{
		var orders = new List<Order>();
		using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
		{
			// Use count to get all available items before the connection closes
			using (SqlCommand cmd = new SqlCommand("PagingProcTest", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
				cmd.Connection.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
                    // Map data to Order class using this way
					orders = DataReaderMapToList<Order>(reader).ToList();
                    // instead of this traditional way
                    // while (reader.Read())
                    // {
                        // var o = new Order();
                        // o.OrderID = Convert.ToInt32(reader["OrderID"]);
                        // o.CustomerID = reader["CustomerID"].ToString();
                        // orders.Add(o);
                    // }
				}
				cmd.Connection.Close();
			}
		}
		return orders;
	}
	private static List<T> DataReaderMapToList<T>(DbDataReader dr)
	{
		List<T> list = new List<T>();
		while (dr.Read())
		{
			var obj = Activator.CreateInstance<T>();
			foreach (PropertyInfo prop in obj.GetType().GetProperties())
			{
				if (!Equals(dr[prop.Name], DBNull.Value))
				{
					prop.SetValue(obj, dr[prop.Name], null);
				}
			}
			list.Add(obj);
		}
		return list;
	}
