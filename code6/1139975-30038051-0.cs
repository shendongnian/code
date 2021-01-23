    public PersonController
    {
      private IPersonBL _personBL;
      public PersonController(IPersonBL personBL)
      {
        _personBL = personBL
      }
      public ActionResult SavePerson(PersonVM model)
      {
         // if ModelState etc etc
         var person = Mapper.Map<Person>(model);
         _personBL.Save(person)
      }
    }
