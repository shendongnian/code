    public FileResult CreateCustomReport()
    {
        ...
        Response.AppendHeader("Content-Disposition", "inline; filename=Out.pdf");
        return File(m.ToArray(), "application/pdf" );
    }
