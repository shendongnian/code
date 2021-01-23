    public ActionResult Index()
            {
                DataTable dtable = new DataTable();
                dtable.Columns.Add("id", typeof(int));
                dtable.Columns.Add("name", typeof(string));
    
                // adding few data to table
                dtable.Rows.Add(1, "Prasad");
                dtable.Rows.Add(2, "Raja");
                dtable.Rows.Add(3, "Hemenath");
                dtable.Rows.Add(4, "Rajesh");
                dtable.Rows.Add(5, "Suresh");
                dtable.Rows.Add(6, "Daniel");
                ViewBag.Units = dtable;
                return View();
            }
