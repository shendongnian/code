                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("header1"), new DataColumn("header2 "), new DataColumn("header3") });
                dt.Rows.Add(cnt , start , end );
               
                GridView1.DataSource = dt;
                GridView1.DataBind();
