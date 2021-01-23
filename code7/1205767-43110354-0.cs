    public ActionResult Index()
        {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";
            return View();
        }
       public ActionResult DocumentViewerPartial() 
       {
        Session["Report"] = new DXApplication.Reports.XtraReport1();
        return PartialView("DocumentViewerPartial");
        }
		
        public ActionResult ExportDocumentViewer()
        {
            return DevExpress.Web.Mvc.DocumentViewerExtension.ExportTo(Session["Report"] as XtraReport1());
        }
