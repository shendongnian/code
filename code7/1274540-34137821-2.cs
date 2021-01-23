    ...
    wsDt.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.None);
    int colNumber = 1;
    foreach (DataColumn col in dt.Columns) 
    {        
        if (col.DataType == typeof(DateTime))
        { 
             wsDt.Column(colNumber++).Style.Numberformat.Format = "MM/dd/yyyy hh:mm:ss AM/PM"
        }          
    }
    wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();
    Response.BinaryWrite(pck.GetAsByteArray());
