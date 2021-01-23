    protected void BindGridview(int anotherid)
    {
       DataSet ds = new DataSet();
       using (SqlConnection con = new SqlConnection("Data Source=source;Integrated Security=true;Initial Catalog=MySampleDB"))
       {
          con.Open();
          SqlCommand cmd = new SqlCommand("SELECT ID, Title FROM Table WHERE AnotherID='"+anotherid+"' ORDER BY ID", con);
          SqlDataAdapter da*emphasized text* = new SqlDataAdapter(cmd);
          da.Fill(ds);
          con.Close();
          gvView.DataSource = ds;
          gvView.DataBind();
    }
