        ...
        using System.Web.Security;
        using Microsoft.AspNet.Identity;
        using ProjectSender.Models;
        ...
        ...
            public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var anonymousUser = args.AnonymousID;
                var identityUser = User.Identity.Name;
                var identityUserId = User.Identity.GetUserId();
    
                foreach (var item in db.Likes.Where(x => x.IUserId == anonymousUser).ToList())
                {
                    //Try = Update anonymousId with identityUserId. 
                    //Catch = Remove any duplicates caught by the exception/constraint
                    try
                    {
                        item.IUserId = identityUserId;
                        item.IUser = identityUser;
                        db.SaveChanges();
                    }
                    catch
                    {
                        db.Likes.Remove(item);
                        db.SaveChanges();
                    }
                }
    
                // Remove the anonymous cookie.
                AnonymousIdentificationModule.ClearAnonymousIdentifier();
            }
        ...
