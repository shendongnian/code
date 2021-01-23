     public static SqlDataAdapter CreateCustomAdapter(int OrderIDInt)
        {
            SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Co-op\Contact\Contact\ContactDataBase.sdf;Password=********");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
