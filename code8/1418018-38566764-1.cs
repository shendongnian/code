    [HttpPost]
        public ActionResult Index()
        {
            string FileContent = "";
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                FileContent = sr.ReadToEnd();
            }
             AfterShip model = JsonConvert.DeserializeObject<AfterShip>(FileContent);
         }
