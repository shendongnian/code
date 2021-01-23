    public ActionResult People()
    {
        List<Person> lstPerson = new List<Person>();
        lstPerson.Add(new Person() { ID = 1, Name = "n1", Link = "l1" });
        lstPerson.Add(new Person() { ID = 2, Name = "n2", Link = "l2" });
        lstPerson.Add(new Person() { ID = 3, Name = "n3", Link = "l3" });
        lstPerson.Add(new Person() { ID = 4, Name = "n4", Link = "l4" });
        TempData["PeopleList"] = lstPerson;
        var model = new PeopleViewModel
        {
           People = lstPerson.Select(
           p => new SelectListItem{ Value = p.ID.ToString(), Text = p.Name}).ToList()
        }
        return View(model);
    }
