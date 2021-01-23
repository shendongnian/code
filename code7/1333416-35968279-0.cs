        public ActionResult Index()
        {
            ViewBag.SelectList = GetDict();
            return View();
        }
        public ActionResult About()
        {
            string strDDLValue = Request.Form["ZoneArea"];
            ViewBag.SelectedValue = strDDLValue;
            ViewBag.SelectList = GetDict();
            return View("Index");
        }
        public Dictionary<string,int> GetDict()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("All", 0);
            dict.Add("North", 1);
            dict.Add("South", 2);
            dict.Add("East", 3);
            dict.Add("West", 4);
            dict.Add("Central", 4);
            return dict;
        }
