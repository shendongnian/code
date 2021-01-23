        SqlConnection conn = new SqlConnection(@"Connection String;");
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        string sql = $"Insert Into BirthDates (Name, DateOfBirth)Values('" + txtName.Text + "','" + date +"')";
        conn.Open();
        SqlCommand command = new SqlCommand(sql, conn);
        command.ExecuteNonQuery();
        conn.Close();
