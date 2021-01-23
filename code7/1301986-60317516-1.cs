            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from [test].[dbo].[myform] order by name", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = conn;
            sda.SelectCommand = cmd;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (sortExpression != null)
                {
                    DataView dv = dt.AsDataView();
                    this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";
                    dv.Sort = sortExpression + " " + this.SortDirection;
                    GridView2.DataSource = dv;
                }
                else
                {
                    GridView2.DataSource = dt;
                }
                GridView2.DataBind();
                conn.Close();
            }
           
        }`
