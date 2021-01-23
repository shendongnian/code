      DataTable dt = new DataTable();
            using (var con = new SqlConnection("Your-Connection-string-here"))
            {
                using (var cmd = new SqlCommand("select * from your-table", con)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            your-grid.DataSourse = null;
            your-grid.DataSourse = dt;
            your-grid.DataBind();
