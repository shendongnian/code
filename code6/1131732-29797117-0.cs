    string Command = "SELECT id, date, contactinfo, orderinfo, contents, print_location, order_id, file_size FROM orders where date between @dateFrom  and @dateTill and print_location like 'antw' or print_location like 'helm'";
    using (MySqlConnection myConnection = new MySqlConnection(ConnectionString))
    {
        using (MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(Command, myConnection))
        {
            myDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("@dateFrom", yourDateFrom));
            myDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("@dateTill", yourdateTill));
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
        }
    }
