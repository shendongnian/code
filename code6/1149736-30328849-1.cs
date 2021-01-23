    public ActionResult PersonView()
    {
       var personWebLogic = new PersonWebLogic(); //would suggest DI instead
       var personsModelList = personWebLogic.GetPersons();
       return View(personsModelList );
    }
