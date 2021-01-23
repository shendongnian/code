    if (connection.State == ConnectionState.Closed) {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * From YazHata order by HataAdi ASC", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ASPxGridView1.DataSource = dt;  // <<<<
                ASPxGridView1.DataBind();  //<<<<<
                da.Dispose();
                connection.Close();
            }
