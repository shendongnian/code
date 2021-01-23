    AllowEmptyStrings = false raises a validation error when user enter blank spaces. It is working fine in below framework. Please try validating object in controller to make sure your annotations are correct. Check modelstate errors.
        
    To test your issue I am using below packages on .net 4.5 (VS 2013, MVC 5)
    EntityFramework" version="6.1.3"
    jQuery" version="2.1.4
    jQuery.Validation" version="1.11.1"
        
        
        public ActionResult Edit(string id)
        {
          ...
          returningModel.PLZ = "  ";
          //returningModel.PLZ = null;
        
          bool b = TryValidateModel(returningModel); 
          var modelStateErrors = ModelState.Values.SelectMany(m => m.Errors);
          return View(returningModel);
        }
