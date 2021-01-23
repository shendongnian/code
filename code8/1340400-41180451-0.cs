    public ActionResult Export() {
        Response.ContentType = "application/x-msexcel"; 
        Response.AddHeader("Content-Disposition", "attachment;filename=ExcelFile.xls");
        return View();
    }
