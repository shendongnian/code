        [HttpGet]
        public ActionResult Logout()
        { 
            Session["id1"] = null;
            Session["id2"] = null;
            Session["id3"] = null;
            Session["id4"] = null;
            Session["Region"] = null;
            Session.Clear();           
            Session.RemoveAll();
            Session.Abandon();
            Response.AddHeader("Cache-control", "no-store, must-revalidate, private, no-cache");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Expires", "0");
            Response.AppendToLog("window.location.reload();");
    
            return RedirectToAction("Index", "Login");
        }
