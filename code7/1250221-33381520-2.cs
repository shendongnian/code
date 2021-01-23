    protected void EXPORT_BUTTON_Click(object sender, EventArgs e)
    {
        // Added Code
        int parseValue;
        bool isInt;
            
        ExcelPackage package = new ExcelPackage();
    
        ExcelWorksheet Grid = package.Workbook.Worksheets.Add("ORSA ASSESSMENTS");
    
        DataTable dt = new DataTable();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            // Update Type
            dt.Columns.Add("column" + i.ToString(), typeof(int));
        }
    
        foreach (GridViewRow row in GridView1.Rows)
        {
            DataRow dr = dt.NewRow();
            for (int j = 0; j < GridView1.Columns.Count; j++)
            {
                row.Cells[j].Text = row.Cells[j].Text.Replace("&nbsp;", " ");
    
                // Added Code
                isInt = int.TryParse(row.Cells[j].Text.Trim(), out parseValue);
                    
                // Added Code
                if (isInt) 
                    dr["column" + j.ToString()] = parseValue;
    
            }
    
            dt.Rows.Add(dr);
        }
    
    
        Grid.Cells["A1"].LoadFromDataTable(dt, true);
    
        using (ExcelRange rng = Grid.Cells["A1:Z1"])
        {
            rng.Style.Font.Bold = true;
        }
    
        Grid.Cells[ORSA.Dimension.Address].AutoFitColumns();
    
    
    
        var FolderPath = ServerName + DirectoryLocation + DirectoryFolder + ExportsFolder;
        var filename = ExcelName + @"_" + ".xlsx";
        var filepath = new FileInfo(Path.Combine(FolderPath, filename));
    
        Response.Clear();
        package.SaveAs(filepath);
        Response.AddHeader("content-disposition", "attachment; filename=" + filename + ";");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xlsx";
        Response.TransmitFile(filepath.FullName);
        Response.End();
    
    }
