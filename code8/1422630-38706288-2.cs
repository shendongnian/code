    // Note: this is an instance (myDB in terms of the GUI Object)
    using System.Data;
    using MySql.Data.MySqlClient;
    ...
    ...
    public long MultBySeven(long theNum)
    {   // Call a Mysql Stored Proc named "multBy7"
        // which takes an IN parameter, Out parameter (the names are important. Match them)
        // Multiply the IN by 7 and return the product thru the OUT parameter
    
        long lParam = 0;
        using (MySqlConnection lconn = new MySqlConnection(connString))
        {
            lconn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = lconn;
                cmd.CommandText = "multBy7"; // The name of the Stored Proc
                cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc
    
                // Two parameters below. An IN and an OUT (myNum and theProduct, respectively)
                cmd.Parameters.AddWithValue("@myNum", theNum); // lazy, not specifying ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@theProduct", MySqlDbType.Int32);
                cmd.Parameters["@theProduct"].Direction = ParameterDirection.Output; // from System.Data
                cmd.ExecuteNonQuery(); // let it rip
                Object obj = cmd.Parameters["@theProduct"].Value;
                lParam = (Int32)obj;    // more useful datatype
            }
        }
        return (lParam);
    }
