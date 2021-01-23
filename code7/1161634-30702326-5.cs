    public ActionResult Index(){
      StudentViewModel objModel; 
      //initialize model
      
      objModel.CssClass = "myCssClass"; //set css class name to viewmodel 
      return View(objModel);
    }
