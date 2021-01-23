        [HttpGet]
        public ActionResult Index(string paging)
        {
            if (!String.IsNullOrEmpty(paging))
            {
                // alternatively use TryParse
                ViewBag.rowsPerPage = int.Parse(paging);
            }
            else
            {
                // default value
                ViewBag.rowsPerPage = 5;
            }
