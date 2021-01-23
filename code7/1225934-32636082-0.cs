      MemoryStream ms = new MemoryStream();
      HtmlToPdf converter = new HtmlToPdf();
      ViewData.Model = model;
      using (var sw = new StringWriter()) {
        var viewengineresult = ViewEngines.Engines.FindPartialView(this.ControllerContext, viewname);
        var viewcontext = new ViewContext(this.ControllerContext, viewengineresult.View, ViewData, TempData, sw);
        viewengineresult.View.Render(viewcontext, sw);
        converter.ConvertHtmlToStream(sw.GetStringBuilder().ToString(), null, ms);
      }
      ms.Position = 0;
      return File(ms, "application/octet-stream", filename);
