    _container.RegisterFactory(container => 
     {
         var user = new User(); 
         user.Roles = container.Resolve<IRolesProvider>()
                .GetRolesForUser(user);
         return user;
     });
