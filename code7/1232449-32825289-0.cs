      if (cmp.contacts == null)
    cmp.contacts = new List<Contact>{
                    new Contact { email = "", name = "", telephone = "" }
                };
      foreach(Contact cont  in cmp.contacts){
              if(!TryValidateModel(cont)){
                ModelState.AddModelError("", "An Invalid Contact Were Found!");
     //       return View(cmp); or
     return View("InvalidContact",cont);
         //you need to create a view nammed InvalidContact to provide more validation error messages
               }
      }
