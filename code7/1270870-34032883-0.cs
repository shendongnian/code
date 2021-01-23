    SqlConnection con = new SqlConnection(connectionString);
    SqlCommand cmd = new SqlCommand("select * from your_table", con);
    try
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        int num = ds.Tables[0].Rows.Count;
        for (int i = 0; i < num - 1; i++)
           //Do something here
    }
    catch (Exception ex)
    {
        //...
    }
    finally
    {
        con.Close();
    }
