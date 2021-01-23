    string query = "Select Count(*) From client Where Username = ? And UserPassword = ?";
    int result = 1;
    using (OleDbConnection conn = new OleDbConnection(connect))
    {
        using (OleDbCommand cmd = new OleDbCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("Username", snameloginBox.Text); //username parameter
            cmd.Parameters.AddWithValue("UserPassword", passwrdloginBox.Text); //userpassword parameter
            conn.Open();
            Session["User"] = nameloginBox.Text;
            result = (int)cmd.ExecuteScalar();
        }   
    }
