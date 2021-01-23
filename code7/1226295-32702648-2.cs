        [HttpPost]
        public ActionResult GenerateReport(FormCollection collection)
        {
            try
            {
                string category = collection["category"];
                // TODO: Add similar information for other fields
                return Redirect(string.format("/Report.aspx?category={0}",category)); //add additional parameters as required
            }
            catch
            {
                return View();
            }
        }
