     using (var context = new PrincipalContext(ContextType.Domain, "MyAdName"))
            {
     var isValidUser = context.ValidateCredentials(model.UserName, model.Password);
                if (!isValidUser)
                {
                         //Do the staff
                }
    }
