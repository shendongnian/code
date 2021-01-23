    [HttpPost]
        public ActionResult SearchReport(string searchVal, string searchParam)
        {
            var reports = m_errandSvc.GetReportSearch(searchVal, searchParam).ToList();
           
            return Content(reports, "application/json");
        }
 
