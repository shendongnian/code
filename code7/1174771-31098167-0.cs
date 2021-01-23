    var Users = (from d in db.Users
                 from s in db.Sales.where(x=>x.Userid==d.id).groupby(x=>x.Userid)
                 select new Models.User
                 {
                    Id = d.Id,
                    UserName = d.UserName,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    EmailAddress = d.EmailAddress,
                    PhoneNumber = d.PhoneNumber,
                    LastPurchase = s.Max(x=>x.SalesDate)
                 }).ToList();
