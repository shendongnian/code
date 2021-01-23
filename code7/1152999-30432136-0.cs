    protected void GetSelectedRecords(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Name"), new DataColumn("Country") });
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (chkRow.Checked)
                {
                    string name = row.Cells[1].Text;
                    string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                    dt.Rows.Add(name, country);
                }
            }
        }
        gvSelected.DataSource = dt;
        gvSelected.DataBind();
    }
