    string query = "insert into Orders" +
                   "(client_id,order_id,date_,card_typ,...)" +
                   " values(@client_id,@order_id,@date_,@card_typ...)";
    using (SqlCommand sqCmd = new SqlCommand(query, con))
    {
        con.Open();
        sqCmd.Parameters.Add("@client_id", SqlDbType.Int).Value = s.ClientId;
        sqCmd.Parameters.Add("@order_id", SqlDbType.VarChar).Value = s.OrderId;
        sqCmd.Parameters.Add("@date_", SqlDbType.DateTime).Value = s.Date;
        sqCmd.Parameters.Add("@card_typ", SqlDbType.Bit).Value = s.CardTyp;
        // add rest of parameters
       //Execute the commands here
    }
