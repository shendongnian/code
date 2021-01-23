    SqlCommand command = new SqlCommand("inserting", con);
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.Add("@Firstname", SqlDbType.NVarChar).Value = TextBox1.Text;
    command.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = TextBox2.Text;
    command.ExecuteNonQuery();
