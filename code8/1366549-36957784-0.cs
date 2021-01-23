     public ActionResult UpdatePassword(UpdatePassword model)
        {
                if (ModelState.IsValid)
                {
                    // your logic
                }
                AddErrors(ModelState);
                return View();
        }
        
        // in my case i have to be add in viewbag
        private void AddErrors(ModelStateDictionary result)
        {
            ViewBag.UpdatePasswordErrorMessages = result;
            //foreach (KeyValuePair<string,System.Web.Mvc.ModelState> error in result)
            //{              
            //    //ModelState.AddModelError(error.Key,error.Value.Errors[0].ErrorMessage);
            //}
        }
