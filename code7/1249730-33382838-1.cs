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
            int num = 0;
            string value = string.Empty;
            ws.Cells[1, 1].LoadFromDataTable(dt, true);
            // Get Your DataTable Count
            int count = dt.Rows.Count;
            int countCol = dt.Columns.Count;
            bool isHeader = true;
            
            for (int i = 0; i < count; i++ )
            {                
                // Set Border
                for (int j = 1; j <= countCol; j++)
                {
                    // Set Border For Header. Run once only
                    if (isHeader) ws.Cells[1, j].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    ws.Cells[2 + i, j].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                }
                // Set to false
                isHeader = false;
                // Cells 2 + i == Rows, Wondering start with 2 because your 1st rows is Title so 2 is the value
                // Cells 2 == Column make sure your column is fix
                value = ws.Cells[2 + i, 2].Value + ""; // You can use .ToString() if u sure is not null
                // Parse
                int.TryParse(value, out num);
                // Check
                if (num >= 1 && num <= 11)
                    ws.Cells[2 + i, 2].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                else if (num >= 12 && num <= 39)
                    ws.Cells[2 + i, 2].Style.Font.Color.SetColor(System.Drawing.Color.Orange);
            }
            pkg.SaveAs(new FileInfo("C:\\Test.xlsx"));
        }
    }
