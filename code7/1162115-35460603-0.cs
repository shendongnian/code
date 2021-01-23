    while (reader.Read())
    {
        //Lets add the data to our list we created earlier...
        customerList.Add(new getCustomerInfoModel
        {
            // What returned values do we want to list...
            UMENT = reader.GetString(0),
            UMCUS = reader.GetDecimal(1),
            UMNAM = reader.GetString(2),
            UMSLC = reader.GetString(3)
        });
    }
