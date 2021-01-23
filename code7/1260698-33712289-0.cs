    Response.ClearHeaders();
    Response.ClearContent();
    Response.ContentType = "Application/octect-stream";
    Response.AppendHeader("Content-disposition", "attachment; filename=SampleFile.xlsx");
    Response.WriteFile(Server.MapPath("~/SampleExcel/SampleFile.xlsx"));
