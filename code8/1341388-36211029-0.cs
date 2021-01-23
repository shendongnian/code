    var users = (from u in userManager.Users       
                  select new UserViewModel
                  {  
                        Id = u.Id, 
                        Username = u.UserName, 
                        Password = u.PasswordHash,
                        Roles =(from r in  roleManager.Roles 
                                 where r.Id==u.Id
                                 select new Role
                                 { 
                                     Name  = r.Name
                                  }).ToList());
