    List<GridViewRow> gridcheckedrows = gvProducts.Rows.Cast<GridViewRow>().Where(x => (x.FindControl("cbAdd") as CheckBox).Checked == true).ToList();
    
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Count");
            dt.Columns.Add("Quantity");
            foreach (GridViewRow gvr in gridcheckedrows)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = gvr.Cells[0].Text;
                dr["Name"] = gvr.Cells[1].Text;
                dr["Price"] = gvr.Cells[2].Text;
                dr["Count"] = "1";
                dr["Quantity"] = "2";
                dt.Rows.Add(dr);
    
            }
            gvProductsList.DataSource = dt;
            gvProductsList.DataBind();
