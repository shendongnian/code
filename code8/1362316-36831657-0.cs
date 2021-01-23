    public ActionResult Index()
    {
        var viewModel = db.test.ToList()
        var viewResult = ExportExcel(viewModel);
        return viewResult;
    }
    //export to excel
    public ActionResult ExportExcel(List<test> viewModel)
    {
        var grid = new GridView();
        grid.DataSource = from p in viewModel
                          select new
                          {
                              Name = p.name,
                              No = p.staffno
                          };
        grid.DataBind();
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.ContentType = "application/ms-excel";
        Response.Charset = "";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grid.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
        return View("MyView");
    }
