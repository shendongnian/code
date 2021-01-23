        public ActionResult Index()
        {
            // Dummy data
            var dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            var row = dt.NewRow();
            row[0] = 4;
            dt.Rows.Add(row);
            ExportExcel(dt);
            return View();
        }
