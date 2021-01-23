    query.Parameters.Add("@AmazonOrderId", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@Name", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@AddressLine1", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@AddressLine2", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@AddressLine3", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@City", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@StateOrRegion", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@Title", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@ItemPrice", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@ShippingPrice", SqlDbType.NVarChar, 150);
    query.Parameters.Add("@Quantity", SqlDbType.NVarChar, 150);
    
    conn.Open();
    foreach (var order in orders)
    {
    	query.Parameters["@AmazonOrderId"].Value = order.AmazonOrderId;
    	query.Parameters["@Name"].Value = order.Name;
    	query.Parameters["@AddressLine1"].Value = order.AddressLine1;
    	query.Parameters["@AddressLine2"].Value = order.AddressLine2;
    	query.Parameters["@AddressLine3"].Value = order.AddressLine3;
    	query.Parameters["@City"].Value = order.City;
    	query.Parameters["@StateOrRegion"].Value = order.StateOrRegion;
    	query.Parameters["@PostalCode"].Value = order.PostalCode;
    	query.Parameters["@Title"].Value = order.Title;
    	query.Parameters["@ItemPrice"].Value = order.ItemPrice;
    	query.Parameters["@ShippingPrice"].Value = order.ShippingPrice;
    	query.Parameters["@Quantity"].Value = order.Quantity;
    	query.ExecuteNonQuery();
    }
    conn.Close();
