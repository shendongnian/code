        [HttpPost]
        public ActionResult HistoryPage(HistoryModel model, string btnAction)
        {
            if (Session["HistoryId"] != null)
            {
                switch (btnAction)
                {
                    case "Delete History":
                        DeleteHistory(model, ref deleteHistoryError, ref deleteHistorySucesss);
                        break;
                    case "AddHistory":
                        AddHistory(model);
                        break;
                }
                return RedirectToAction("Get Action Name ...");
            }
            return View(model);
        }
