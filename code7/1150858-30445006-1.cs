     protected void btExcel_Click(object sender, EventArgs e)
    {
        XLWorkbook wb = new XLWorkbook();
        GridView[] gvExcel = new GridView[] { GridView1, GridView2, GridView3, GridView4, GridView5, GridView6};
        string[] name = new string[] { "Name1", "Name2", "Name3", "Name4", "Name5", "Name6" };
        for (int i = 0; i < gvExcel.Length; i++)
        {
            if (gvExcel[i].Visible)
            {
                gvExcel[i].AllowPaging = false;
                gvExcel[i].DataBind();
                DataTable dt = new DataTable(name[i].ToString());
                for (int z = 0; z < gvExcel[i].Columns.Count; z++)
                {
                    dt.Columns.Add(gvExcel[i].Columns[z].HeaderText);
                }
                foreach (GridViewRow row in gvExcel[i].Rows)
                {
                    dt.Rows.Add();
                    for (int c = 0; c < row.Cells.Count; c++)
                    {
                        dt.Rows[dt.Rows.Count - 1][c] = row.Cells[c].Text;
                    }
                }
               
                wb.Worksheets.Add(dt);
                gvExcel[i].AllowPaging = true;
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=Workbook_Name.xlsx");
        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
