    using(var myConnection = new SqlConnection(conString))
    using(var check_details = myConnection.CreateCommand())
    {
        check_details.CommandText = @"select Account_num, Pin_num from Cust_details 
                                      where Account_num = @accnum
                                      and Pin_num = @pinnum";
        // I assume your column types as Int
        check_details.Parameters.Add("@accnum", SqlDbType.Int).Value = int.Parse(txt_acc.Tex);
        check_details.Parameters.Add("@pinnum", SqlDbType.Int).Value = int.Parse(txt_pin.Text);
        myConnection.Open();
        int result = (int)check_details.ExecuteScalar();
        ...
    }
