        public DataTable MockDataTable
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("CheckBoxes");
                dt.Rows.Add(new object[] { "Alex", "Hello" });
                dt.Rows.Add(new object[] { "Alex", "World" });
                dt.Rows.Add(new object[] { "Alex", "Etc" });
                return dt;
            }
        }
        public ActionResult Index()
        {
            // here you do your db query
            var dt= MockDataTable;
            // convert it to List<string>
            var result = dt.Rows.OfType<DataRow>()
                .Select(dr => dr.Field<string>("CheckBoxes")).ToList();
            return View(result);
        }
