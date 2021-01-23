        public ActionResult Index()
        {
            Dictionary<string, int> datas = new Dictionary<string, int>();
            datas.Add("Januar 2015", 3129);
            datas.Add("Februar 2015", 3129);
            ChartModel model = new ChartModel();
            model.DataRows = string.Join(Environment.NewLine, datas.Select(d => "[" + d.Key + "," + d.Value + "]"));
            return View(model);
        }
