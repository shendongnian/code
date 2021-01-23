    public ActionResult Index(string PdfUrl)
        {
            var model = new DocOnDemandModel();
            string Domain = Request.UrlReferrer.Host;
            string PageUrl = Request.UrlReferrer.OriginalString;
            DateTime Time = DateTime.Now;
    
            model.PageUrl = PageUrl;
            model.Domain = Domain;
            model.PdfUrl = PdfUrl;
            model.Time = Time;
    
            return View(model);
        }
