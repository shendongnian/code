            DataTable dt = ds.Tables[0].Copy();
            if (!dt.Columns.Contains("SortBy"))
              dt.Columns.Add("SortBy", typeof (Int32));
            foreach (DataColumn col in dt.Columns)
              col.ReadOnly = false;
            Random rnd = new Random();
            foreach (DataRow row in dt.Rows)
            {
              row["SortBy"] = rnd.Next(1, 100);
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "SortBy";
            DataTable sortedDT = dv.ToTable();
            rprItems.DataSource = sortedDT;
            rprItems.DataBind();
