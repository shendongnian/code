            DataTable dt= new DataTable();
            DataColumn dc1 = new DataColumn("PropertyName");
            DataColumn dc2 = new DataColumn("PropertyID"); 
            DataColumn dc3 = new DataColumn("Postdate");
            DataColumn dc4 = new DataColumn("columnName4");
            DataColumn dc5 = new DataColumn("columnName5");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            foreach (DataRow row in datatable.Rows)
            {
                DataRow dr = dt.NewRow();
                dr[0] = row[propertyname];
                dr[1] = row[Propertytype];
                dr[2] = row[postdate];
                dr[3] = "YES";
                dr[4] = "NO";
                dt.Rows.Add(dr);
            }
            GridView1.DataSource = dt;
