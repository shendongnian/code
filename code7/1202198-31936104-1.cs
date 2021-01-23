    string Command = "select top 1 text from tbl_HomepageContent where company = @company";
    using (SqlConnection myConnection = new SqlConnection(con))
    {
        myConnection.Open();
        using (SqlCommand myCommand = new SqlCommand(Command, myConnection))
        {
            myCommand.Parameters.Add(new SqlParameter("@company", "jagsar"));
            lblHomepageContent.Text = (string)myCommand.ExecuteScalar();
        }
    }
