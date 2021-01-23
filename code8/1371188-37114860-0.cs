     public ActionResult FirstAction()
        {
            return RedirectToAction("SecondAction",
                new { test = Request.Url.ToString() });
        }
        
        public ActionResult SecondAction()
        {
            return Redirect(Request.QueryString["test"]);
        }
