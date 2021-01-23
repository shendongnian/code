    private DataTable dt = new DataTable();
    private DataView dv;
    private void Page_Load(object sender, System.EventArgs e)
    {
        dt.Columns.Add("Id");
        dt.Columns.Add("EmployeeName");
        dt.Columns.Add("EmployeeFamily");
        for (int i = 0; i < 10; i++)
        {
            var r1 = dt.NewRow();
            r1["Id"] = i + 100;
            r1["EmployeeName"] = "Name " + i.ToString();
            r1["EmployeeFamily"] = "Family " + i.ToString();
            dt.Rows.Add(r1);
        }
        dv = new DataView(dt);
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    private MemoryStream GetStream(XLWorkbook excelWorkbook)
    {
        MemoryStream fs = new MemoryStream();
        excelWorkbook.SaveAs(fs);
        fs.Position = 0;
        return fs;
    }
    protected void ButtonFilter_Click(object sender, EventArgs e)
    {
        dv.RowFilter = $"EmployeeName LIKE '%{TextBox1.Text}%' OR EmployeeFamily LIKE '%{TextBox1.Text}%'";
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    protected void ButtonExport_Click(object sender, EventArgs e)
    {
        dv = new DataView(dt);
        dv.RowFilter = $"EmployeeName LIKE '%{TextBox1.Text}%' OR EmployeeFamily LIKE '%{TextBox1.Text}%'";
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dv.ToTable(), "Employees");
            string myName = HttpContext.Current.Server.UrlEncode("Employees.xlsx");
            MemoryStream stream = GetStream(wb);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + myName);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.BinaryWrite(stream.ToArray());
            HttpContext.Current.Response.End();
        }
    }
