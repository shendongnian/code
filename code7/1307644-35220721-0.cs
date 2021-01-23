    if (Response.IsClientConnected)
    {
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;  filename=" + departmentName + ".xlsx");
        Response.BinaryWrite(excelPackage.GetAsByteArray());
        Response.Flush();
        Response.End();
    }
