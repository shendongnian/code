           //First DataTable
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("ID");
            DataColumn dc1 = new DataColumn("Name");
            dt.Columns.AddRange(new DataColumn[] {dc, dc1 });
            DataRow dr = dt.NewRow();
            dr[dc] = "1";
            dr[dc1] = "Test";
            dt.Rows.Add(dr);
            //Second DataTable
            DataTable dt1 = new DataTable();
            DataColumn dc2 = new DataColumn("ID");
            DataColumn dc3 = new DataColumn("City");
            dt1.Columns.AddRange(new DataColumn[] { dc2, dc3 });
            DataRow dr1 = dt1.NewRow();
            dr1[dc2] = "1";
            dr1[dc3] = "Belgium";
            dt1.Rows.Add(dr1);
            //Rasult DataTable
            DataTable result = new DataTable();
            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("Name");
            DataColumn col3 = new DataColumn("City");
            result.Columns.AddRange(new DataColumn[] { col1, col2, col3 });
            // Join both table data
            var data = from row1 in dt.AsEnumerable()
                       join row2 in dt1.AsEnumerable()
                       on row1.Field<string>("ID") equals row2.Field<string>("ID") into test
                       from rw in test.DefaultIfEmpty()
                       select result.LoadDataRow(new object[]
                        {
                             row1.Field<string>("ID"),
                             row1.Field<string>("Name"),
                             rw == null ? "No City" : rw.Field<string>("City")
                        }, false);
            data.CopyToDataTable();
