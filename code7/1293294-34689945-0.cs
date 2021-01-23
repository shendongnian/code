    if(Model.IsValid)
    {
       if(Membership.ValidateUser(model.Username, model.Password))
       { 
          // User is valid
       }
    }
