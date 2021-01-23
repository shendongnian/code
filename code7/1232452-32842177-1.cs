    if (cmp.contacts == null || !cmp.contacts.Any())
    {
      var newContact = new Contact(); // no need to set the values to empty strings
      cmp.contacts = new List<Contact>{ newContact };
      // validate
      var context = new ValidationContext(newContact);
      var results = new List<ValidationResult>();
      Validator.TryValidateObject(newContact, context, results);
      // add errors to ModelState
      foreach(var result in results)
      {
        var propertyName = string.Format("contacts[0].{0}", result.MemberNames.First());
        ModelState.AddModelError(propertyName, result.ErrorMessage);
      }
      return View(cmp);
    }
            
