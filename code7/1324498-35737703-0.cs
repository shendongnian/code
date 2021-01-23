    var query = (from user in chatDBContext.tbl_User
                     select new
                         {
                         user.FirstName, user.LastName, user.Gender, user.Email,
                         user.DoB, user.Address, user.City, user.State,user.Country,
                         user.Quote, user.username, user.image = user.Image
                          }
                     ).ToList()
                 .Select(c => new {
                         FirstName = c.FirstName, LastName = c.LastName, Gender = c.Gender, Email = c.Email,
                         DoB = c.DoB, Address = c.Address, City = c.City, State = c.State, Country = c.Country,
                         Quote = c.Quote, username = c.username, image = plugins.LoadImage(c.image)
                          }).ToList();
