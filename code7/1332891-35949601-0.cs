            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof (string));
            dt.Columns.Add("Health", typeof (int));
            dt.Columns.Add("Type", typeof (string));
            DataRow row = dt.NewRow();
            row["ID"] = "a1";
            row["Health"] = 40;
            row["Type"] = "type1";
            dt.Rows.Add(row);
