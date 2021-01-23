    public ActionResult Export()
    {
        Response.ContentType = "application/x-msexcel"; 
        Response.AddHeader("Content-Disposition", "attachment; filename=ExcelFile.xls");
        return PartialView("Address_Book_Partial_View_FileName_Here_Without_Extension");
    }
