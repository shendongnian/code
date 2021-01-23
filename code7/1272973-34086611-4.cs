    public ActionResult Complete(int? id)
    {
        if(int != null && int != 0){ //Makes sure int isn't empty or 0
           var allModelData = dataContext(); //Get all the data in your dataContext
           var myModel = allModelData.FirstOrDefault(x => x.id == id); //This gets the 
                                                                //model that matches the ID
           CheckOutViewModel viewModel = myModel; //Populate it into your viewmodel
           return View(viewModel); //Return your viewmodel
        }
        return View();
    }
