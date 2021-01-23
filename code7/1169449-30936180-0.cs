    DateTime DateTimeValue;
    string DateTimeString = txtDate.Text.Trim() +' '+ txtTime.Text.Trim();
    if(DateTime.TryParse(DateTimeString, out DateTimeValue))
    {
        using(SqlConnection con = new SqlConnection("ConnectionString")) {
            SqlCommand cmd = new SqlCommand("insert into table(date) values(@Value)", con);
            cmd.Parameters.Add("@Value", SqlDbType.DateTime).value = DateTimeValue;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
