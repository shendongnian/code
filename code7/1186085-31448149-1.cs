    protected void Button1_Click1(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("Name");
        dt.Columns.Add("Address");
        dt.Columns.Add("Number");
        //First fill all the date present in the grid
        for (int intCnt = 0; intCnt < GridView1.Rows.Count; intCnt++)
        {
            if (GridView1.Rows[intCnt].RowType == DataControlRowType.DataRow)
            {
                dr = dt.NewRow();
                dr["Name"] = GridView1.Rows[intCnt].Cells[0].Text;
                dr["Address"] = GridView1.Rows[intCnt].Cells[1].Text;
                dr["Number"] = GridView1.Rows[intCnt].Cells[2].Text;
                dt.Rows.Add(dr);
            }
        }
        dr = dt.NewRow();
        dr["Name"] = TextBox1.Text;
        dr["Address"] = TextBox2.Text;
        dr["Number"] = TextBox3.Text;
        dt.Rows.Add(dr);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }   
