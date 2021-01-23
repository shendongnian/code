    int sheetcount = 1;
    using (XLWorkbook wb = new XLWorkbook())
    {
        // copy over the Columns as XmlSchema
        var ms = new MemoryStream();
        dt.WriteXmlSchema(ms);
        
        // read back the schema it the target 
        ms.Position = 0;
        DataTable tempdt = new DataTable();
        tempdt.ReadXmlSchema(ms);
        
        foreach (DataRow row in dt.Rows)
        {    
            tempdt.ImportRow(row);
            if (tempdt.Rows.Count == 64000)
            {
                wb.Worksheets.Add(tempdt, String.Format("{0}{1}", comboBox1.SelectedItem,  sheetcount));
                sheetcount++;    
                tempdt.Clear(); // reset to zero rows
            }
        }
        // copy final/left over rows of the DataTable
        if (tempdt.Rows.Count > 0) 
        {
            wb.Worksheets.Add(tempdt, String.Format("{0}{1}", comboBox1.SelectedItem,  sheetcount));
            sheetcount++;    
        }
        tempdt.Dispose(); 
        wb.SaveAs(String.Format("{0}\\{1}_{2:ddMMyyhhmmss}.xslx",folderpath, comboBox1.SelectedItem, mydatetime));
    }
