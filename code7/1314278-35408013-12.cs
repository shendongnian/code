    protected void ExportExcel(object sender, EventArgs e)
    {
        DataTable dt = new DataTable("GridView_Data");
        foreach (DataControlField col in GridView4.Columns)
        {
            dt.Columns.Add(col.HeaderText);
        }
        foreach (GridViewRow row in GridView4.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[dt.Rows.Count - 1][i] = (FindControl(row.Cells[i].Controls, "lbl") as Label).Text;
            }
        }
    }
    protected Control FindControl(ControlCollection collection, string id)
    {
        foreach (Control ctrl in collection)
        {
            if (ctrl.ID == id)
                return ctrl;
        }
        return null;
    }
