    // New model, specific for request
    public class UserRequestViewModel
    {
        [Required(ErrorMessage="FirstName")]
        public string FirstName { get; set; }
    
        [Required(ErrorMessage = "LastName")]
        public string LastName { get; set; }
    }
    public ActionResult Index(UserRequestViewModel requestModel)
    {
        //... do something
        // Get the values required to return to the view
        var responseModel = new UserViewModel();
        responseModel.DesiredUnits = new List<UnitViewModel>();
        // Return the response model
        return View(responseModel);
    }
