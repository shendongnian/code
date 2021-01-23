    //Get Subtotal
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	// Initialize
    	long _CategoryID = Convert.ToInt64(dt.Rows[i]["CategoryID"]);
    	double Admin = 0; double Interest = 0;
    	double Penalties = 0; double TotalAmount = 0; string Title = string.Empty;
    	// Process    
    	do
    	{
    		Admin += Convert.ToDouble(dt.Rows[i].IsNull("Admin") ? 0.0 : dt.Rows[i].Field<double>("Admin"));
    		Interest += Convert.ToDouble(dt.Rows[i].IsNull("Interest") ? 0.0 : dt.Rows[i].Field<double>("Interest"));
    		Penalties += Convert.ToDouble(dt.Rows[i].IsNull("Penalties") ? 0.0 : dt.Rows[i].Field<double>("Penalties"));
    		TotalAmount += Convert.ToDouble(dt.Rows[i].IsNull("TotalAmount") ? 0.0 : dt.Rows[i].Field<double>("TotalAmount"));
    		i++;
    	}
    	while (i < dt.Rows.Count && _CategoryID == Convert.ToInt64(dt.Rows[i]["CategoryID"]));
    	// Consume    
    	dt.Rows.InsertAt(dt.NewRow(), i);
    	dt.Rows[i]["CategoryID"] = _CategoryID;
    	dt.Rows[i]["Category"] = "Subtotal";
    	dt.Rows[i]["Admin"] = Admin;
    	dt.Rows[i]["Interest"] = Interest;
    	dt.Rows[i]["Penalties"] = Penalties;
    	dt.Rows[i]["TotalAmount"] = TotalAmount;
    }
