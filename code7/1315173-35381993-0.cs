    public void GetData()
    {
        var db = new TestDBEntities();
        var sw = new StringWriter();
        var htw = new HtmlTextWriter(sw);
        var dg = new DataGrid();
        dg.DataSource = db.Htmls.ToList(); 
        dg.DataBind();
        dg.RenderControl(htw);
        dvFirstDiv.InnerHtml = sw.ToString(); 
    } 
