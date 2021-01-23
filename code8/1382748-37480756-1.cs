    //Example how to Format Column 1 as numeric 
    using (ExcelRange col = ws.Cells[2, 1, 2 + tbl.Rows.Count, 1])
    {
        col.Style.Numberformat.Format = "#,##0.00";
        col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
    }
