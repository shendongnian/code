    if(!string.IsNullOrEmpty((string)Session["PersonSession"]))
        {
          Person newPerson = new Person();
        }
        else
        {
          Person newPerson = (Person)Session["PersonSession"];
        }
    
    ViewBag.PersonName = newPerson.name.toString;
    return View();
