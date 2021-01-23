    public IActionResult YourAction() {
        
        IEnumerable<SelectListItem> names = db.People.Select( dbPerson => new SelectListItem() {
            Text = dbPerson.FirstName + " " + dbPerson.LastName,
            Value = dbPerson.Id.ToString()
        } );
        return this.View( new YourViewModel() { Names = names } );
    }
    [HttpPost]
    public IActionResult YourAction(YourViewModel model) {
        
        DBPerson dbPerson = db.People.GetPerson( model.SelectedNameByPersonId );
        // do stuff with person
    }
