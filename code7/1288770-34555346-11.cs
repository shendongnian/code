    using System.Globalization;
    ....
    ....
    public void EditCustomers( string _id,string _fName, string _lName,string _phone, string _address)
    {
        int idValue = -1;
        if (!int.TryParse(_id, NumberStyles.Integer, CultureInfo.InvariantCulture, out idValue))
        {
           string message = "Id must be a string which contains an integer value, the value of 'id' was: '" + _id + "'";
           throw new ArgumentException("_id", message); 
        }
        Connection_String = @"Data Source=MOSTAFA-PC;Initial Catalog=" + "Sales and Inventory System" + ";Integrated Security=TrueData Source=MOSTAFA-PC;Initial Catalog=" + "Sales and Inventory System" + ";Integrated Security=True;";
        Query = @"update Customers 
                      set FName=@_fName, LName=@_lName, Phone=@_phone,[Address]=@_address
                      where Id = @_id";
        using (Con=new SqlConnection(Connection_String))
        using (Cmd=new SqlCommand(Query, con))
        {
            Cmd.Parameters.AddWithValue("@_fName", _fName);
            Cmd.Parameters.AddWithValue("@_lName", _lName);
            Cmd.Parameters.AddWithValue("@_phone", _phone);
            Cmd.Parameters.AddWithValue("@_address", _address);
            Cmd.Parameters.AddWithValue("@_id", idValue);
            Con.Open();
            Cmd.ExecuteNonQuery();
        }
    }   
