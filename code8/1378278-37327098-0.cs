    var personDetails = new PersonDetails()
    var p = new PersonBusiness().GetByPrimaryKey(mdl.PersonID);
    personDetails.Name1 = p.Name1;
    personDetails.Name2 = p.Name2;
    return View("ViewName", new SmartClinic.Models.Person { PersonDetails = personDetails });
