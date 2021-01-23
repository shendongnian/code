    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            
            // Create Column
            for(int i = 0; i < 5; i++)
                dt.Columns.Add("column" + i, typeof(int));
            for (int i = 0; i < 10; i++)
                dt.Rows.Add(i, i+1, i+2, i+3, i+4);
            GenerateExcel(dt);
        }
    }
    private void GenerateExcel(DataTable dt)
    {
        using (ExcelPackage pkg = new ExcelPackage())
        {
            ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Sheet1");
            ws.Cells[1, 1].LoadFromDataTable(dt, true);
            pkg.SaveAs(new FileInfo("C:\\Test.xlsx"));
        }
    }
