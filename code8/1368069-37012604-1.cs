    string cmdText = "SELECT itemName FROM Products WHERE description = @desc";
    Button b = (Button)sender;
    SqlCommand subcmd = new SqlCommand(cmdText, con);
    subCmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = b.Text;
    SqlDataAdapter subda = new SqlDataAdapter(subcmd);
    DataTable subdt = new DataTable();
    subda.Fill(subdt);
