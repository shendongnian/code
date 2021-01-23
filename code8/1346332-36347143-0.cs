    string sql = "SELECT name FROM students WHERE s_id = '" + 123 + "'";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            name = (string)cmd.ExecuteScalar();
            if(textBox1.text == myString)
            {
              confirm.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
