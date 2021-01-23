    public ActionResult Check()
        {
            var chk = Session["names"];
            List<Details> list = Session["names"] as List<Details>;
            ViewBag.MyList = list ;
            return View();
        }
