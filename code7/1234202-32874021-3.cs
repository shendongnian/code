    public IActionResult YourAction() {
        
        List<SelectListItem> names = db.People.Select( dbPerson => new SelectListItem() {
            Text = dbPerson.FirstName + " " + dbPerson.LastName,
            Value = dbPerson.Id.ToString()
        } ).ToList(); // ToList so the DB is only queried once
        return this.View( new YourViewModel() { Names = names } );
    }
    [HttpPost]
    public IActionResult YourAction(YourViewModel model) {
        
        DBPerson dbPerson = db.People.GetPerson( model.SelectedNameByPersonId );
        // do stuff with person
    }
