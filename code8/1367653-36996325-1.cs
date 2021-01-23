    var cmd = new SqlCommand("SELECT DISTINCT type FROM Products ORDER BY type ASC", con);
    con.Open();
    try
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            tabControl1.TabPages.Add(dr["type"].ToString());
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error");
    }
    con.Close();
