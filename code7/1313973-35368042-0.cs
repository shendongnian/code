    protected void cmdRefresh_Click(object sender, EventArgs e)
    {
            SqlConnection conn = new SqlConnection(connectionManager.getConnectionString("myDB"));
            SqlCommand cmd = new SqlCommand("myQry", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader rdr;
            cmd.Parameters.Add(new SqlParameter("@Par1", chkCaseSearch.Checked));
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            grdView1.DataSource = rdr;
            grdView1.DataBind();
    }
