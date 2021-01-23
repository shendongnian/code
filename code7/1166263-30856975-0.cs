    var model = new ViewModel();
     var isSuccess = TryUpdateModel(model);
    
     if (!isSuccess)
     {
         foreach (var modelState in ModelState.Values)
         {
            foreach (var error in modelState.Errors)
            {
               Debug.WriteLine(error.ErrorMessage);
            }
         }
     }
