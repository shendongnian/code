    SqlCommand cmdd = new SqlCommand();
    cmdd.CommandText = "select * from [users]";
    cmdd.Connection = conn;
    SqlDataReader rd = cmdd.ExecuteReader();
    while (rd.Read())
    {
        if (rd[1].ToString() == TextBox_To.Text)
        {
            flag = false;
            break;
        }
    }
    conn.Close();
