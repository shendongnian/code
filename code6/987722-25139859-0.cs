    DataTable dtFinal = new DataTable();
    foreach (string conString in arr)
    {
        DataTable dtTemp = new DataTable();
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * from some sys.dm", con))
            {
                con.Open();
                dtTemp.Load(cmd.ExecuteReader());
                dtFinal.Merge(dtTemp);
            }
        }
    }
    GridView1.DataSource = dtFinal;
    GridView1.DataBind();
