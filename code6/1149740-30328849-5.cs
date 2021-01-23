    public List<PersonListItemViewModel> GetPersons()
    {
       var personService = new PersonService(); //suggest DI here again
       var people = personService.GetPeople(); //returns a list of domain models
       var personsViewModelList = new List<PersonListItemViewModel>();
       foreach(var person in people)
       {
         //use some custom function to convert PersonDomainModel to PersonListItemViewModel
         personalsViewModel.Add(MapPersonDomainToPersonView(person)); 
       }
       return personsViewModelList;
    }
