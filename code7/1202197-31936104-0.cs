    string Command = "select top 1 text from tbl_HomepageContent where company = 'jagsar'";
    using (SqlConnection myConnection = new SqlConnection(con))
    {
        myConnection.Open();
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            lblHomepageContent.Text = (string)myCommand.ExecuteScalar();
        }
    }
