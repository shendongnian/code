    public ActionResult Edit(int id)
    {
        var data_model = TheContactContext.tblContacts.Get(id); // get model probably from database
        var view_model = new ContactsCreateViewModel() {
            Company = data_model.Company,
            ...
        }; // copy all data into view model
        return View(view_model); // and display view
    }
