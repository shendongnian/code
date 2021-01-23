    public static void UpdateRationFeeds(Form1 frm)
    {
        string StrCon = System.Configuration.ConfigurationManager.ConnectionStrings["FeedLibraryConnectionString"].ConnectionString;
        OleDbConnection Connection = new OleDbConnection(StrCon);
        OleDbCommand Cmd = new OleDbCommand();
        Cmd.Connection = Connection;
        double Quantity = Convert.ToDouble(frm.RationFeedsdataGridView.CurrentCell.Value);
        string FeedName = frm.RationFeedsdataGridView.CurrentRow.Cells[1].Value.ToString();
        Connection.Open();
        Cmd.CommandText = "Update SelectedFeeds set Quantity=@quantity Where SelectedFeeds.[Feed Name]=@feedname";
        Cmd.Parameters.Add("@quantity", OleDbType.Double).Value = Quantity;
        Cmd.Parameters.Add("@feedname", OleDbType.LongVarChar).Value = FeedName;
        Cmd.ExecuteNonQuery();
        Connection.Close();
    }
