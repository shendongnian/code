    public ActionResult Edit(Guid? id)
    {
        WafeERP_NEWEntities db = new WafeERP_NEWEntities();
        View_VisitorsForm model = db.View_VisitorsForm.Find(id);
        VisitorsViewModel viewModel = new VisitorsViewModel()
        {
            VisitingID = model.VisitingID,
            ....
            // Add the following
            CustomerContactID = model.CustomerContactID,
            CustomerContactList = db.CustomerContacts.Where(x => x.CustomerID == model.CustomerContactID).Select(x => new SelectListItem()
            {
                Value = CustomerContactID,
                Text = ContactReference
            },
            .... // add the other select lists
        };
        return View(viewModel);
    }
