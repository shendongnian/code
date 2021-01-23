    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(Person p)
    {
        using (testContext test = new testContext())
        {
            if (ModelState.IsValid)
            {
                try
                {
                    test.persons.Add(p);
                    test.SaveChanges();
                    ViewBag.Message = "Success";
                }
                catch (Exception ec)
                {
                    ViewBag.Message = ec.Message;
                }
            }
        }
        ViewBag.Datalist = GetGenders();
        return View(p);
    }
