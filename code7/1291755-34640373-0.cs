    using (var connection = new SqlConnection(SQL))
    using (var command = new SqlCommand("SELECT TOP 1 Number FROM TestTable.dbo.users WHERE LoginName = @UserName;", connection))
    {
        command.Parameters.Add("@UserName", SqlDbType.VarChar, 25).Value = viewerUserNameTxtBox.Text
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string test = reader.GetString(0);
                Session["viewerNumber"] = test;
            }
        }
    }
