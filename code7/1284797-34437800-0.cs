     using (ExcelPackage pck = new ExcelPackage())
    {
        //Create the worksheet
        var ws = pck.Workbook.Worksheets.Add("Demo");
        //Load the datatable into the sheet, starting from cell A1.
        // Print the   column names on row 1
        var table=ws.Cells["A1"].LoadFromCollection(model, true);
        //Write it back to the client
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");
        Response.BinaryWrite(pck.GetAsByteArray());
    }
