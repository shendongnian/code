            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Code");
            System.Data.DataRow r = dt.NewRow();
            r["Code"] = "30500";
            dt.Rows.Add(r);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                row["CODE"] = row["CODE"].ToString().PadLeft(8, '0');
            }
            dt.AcceptChanges();
