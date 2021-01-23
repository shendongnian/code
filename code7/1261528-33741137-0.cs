    SqlConnection con = new SqlConnection("Data Source=ZON-PC;Initial Catalog=RestaurantPOSSOC;Integrated Security=True");
    con.Open();
    foreach (ListViewItem item in listView1.Items)
    {
        SqlCommand _sqlcommand = new SqlCommand("insert into OrderInfo (ProductName,Quantity,Price)values('" + item.SubItems[0].Text + "','" + item.SubItems[1].Text + "','" + item.SubItems[2].Text + "')", con);
        SqlDataReader _sqldatareader = _sqlcommand.ExecuteReader();
        _sqldatareader.Read();
    }
    con.Close();
