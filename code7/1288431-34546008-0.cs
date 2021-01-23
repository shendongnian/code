    byte[] file = ReportViewer1.LocalReport.Render(some parameters);
    
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "inline;filename=Test.pdf");
    Response.Buffer = true;
    Response.Clear();
    Response.BinaryWrite(file);
    Response.End();
