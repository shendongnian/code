        //public ActionResult Index()
        //{
        //    ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
        //    return View(this.apiDescriptionCollection);
        //}
        public ActionResult Index(string webservice)
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            if (!string.IsNullOrEmpty(webservice))
            {
                Collection<ApiDescription> apiCollection = new Collection<ApiDescription>();
                foreach (ApiDescription desc in this.apiDescriptionCollection)
                {
                    if (desc.GetControllerName() == ("ws_" + webservice))
                        apiCollection.Add(desc);
                }
                if (apiCollection.Count > 0)
                    this.apiDescriptionCollection = apiCollection;
            }
            return View(this.apiDescriptionCollection);
        }
