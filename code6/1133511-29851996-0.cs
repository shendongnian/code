     string cs = ConfigurationManager.ConnectionStrings["TrishanConnection"].ConnectionString;
     using(SqlConnection con = new SqlConnection(cs))
     {
        using (SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 coil_id FROM CoilDetails ORDER BY coil_id DESC", con))
        {
            con.Open();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            dt=ds.Table[0]
         }
     }
     LabeCoilid.Text = dt.Rows[0][0].ToString();
     LabeCoilid.DataBind();
     con.Close();
