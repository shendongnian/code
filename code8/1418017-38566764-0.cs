    [HttpPost]
        public ActionResult Index()
        {
            string FileContent = "";
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                FileContent = sr.ReadToEnd();
            }
            dynamic model = JObject.Parse(FileContent);
            // model.tracking_number 
            // model.tag  - model.title
         }
