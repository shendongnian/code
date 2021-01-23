    private void binddata()
    {
        DataTable dt = new DataTable();
        using (SqlDataAdapter adp = new SqlDataAdapter(data, connstring))
        {
            adp.Fill(dt);
            hjuldata.DataContext = dt;
            hjuldata.DataBind();
        }
    }
    private void bindhast()
    {
        DataTable dts = new DataTable();
        using (SqlDataAdapter adph = new SqlDataAdapter(hast, connstring))
        {
            adph.Fill(dts);
            hast_list.DataContext = dts;
            hast_list.DataBind();
        }
    }
