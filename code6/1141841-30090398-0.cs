     Response.AddHeader("content-disposition", "attachment;filename=ExportDataDateSearch.xls");
    
    // Insert below
    Response.ContentType = "application/ms-excel";
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
