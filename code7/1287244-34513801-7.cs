    [HttpPost]
    public ActionResult CreateUser(MedicineMasterVm model)
    {
        if (ModelState.IsValid)
        {
            string[] supplierArray= model.SelectedSuppliers  ;
            //check items now
            //do your further things and follow PRG pattern as needed
        }
        //reload the Suppliers property again in the ViewModel before returning to the View
        return View(model);
    }
