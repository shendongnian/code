     public static SqlDataAdapter CreateCustomAdapter(int OrderIDInt)
        {
            SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Co-op\Contact\Contact\ContactDataBase.sdf;Password=********");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("select Id, Name, Adress, Phone, Email from [The name of the table]", coמ);
