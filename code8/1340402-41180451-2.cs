    public ActionResult Export()
    {
        Response.ContentType = "application/excel"; 
        Response.AddHeader("Content-Disposition", "attachment; filename=ExcelFile.xslx");
        return PartialView("Address_Book_Partial_View_FileName_Here_Without_Extension");
    }
