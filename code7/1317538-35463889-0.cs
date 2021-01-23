    protected void Button1_Click(object sender, EventArgs e)
    {
        var cs = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            con.Open();
            var cmd = new SqlCommand(
				"DECLARE @IDReturnTable TABLE( ID INT ); INSERT INTO [booking] OUTPUT INSERTED.NameOfYourIdColumn INTO @IDReturnTable VALUES(@param1, @param2, @param3); SELECT ID FROM @IDReturnTable", 
				con);
			cmd.Parameters.Add("@param1", SqlDbType.VarChar).Value = TextBox1.Text;
			cmd.Parameters.Add("@param2", SqlDbType.VarChar).Value = TextBox2.Text;
			cmd.Parameters.Add("@param3", SqlDbType.VarChar).Value = TextBox3.Text;
            var returnedId = cmd.ExecuteScalar();
        }
    }
