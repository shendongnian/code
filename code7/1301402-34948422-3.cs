          public ActionResult Index()
        {
            Test tst = new Test();
            tst.Ages = new List<SelectListItem>();
            tst.Ages.Insert(0, (new SelectListItem { Text = "", Value = "" }));
            for (int i = 1; i < 100; i++)
            {
                tst.Ages.Insert(i, new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return View(tst);
        }
