    var appDbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
    using (var identitydbContextTransaction = appDbContext.Database.BeginTransaction())
    {
       try
       {
           var result = await UserManager.CreateAsync(user, "password");
           if (result.Succeeded)
           {
             var userinfo = await UserManager.FindByNameAsync("Email");
             var userId = user.Id;
             await UserManager.AddToRoleAsync(userId, "rolename");
             identitydbContextTransaction.Commit();
           }
      }
      catch (Exception)
      {
            identitydbContextTransaction.Rollback();
      }
    }
