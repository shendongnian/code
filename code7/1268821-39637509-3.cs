     // below method is new to get the UserId and Role
     public ActionResult LoginRoute(string returnUrl)  //this method is new
        {
            if (String.IsNullOrWhiteSpace(returnUrl))
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToLocal("/Admin");
                }
                else if (User.IsInRole("Partner"))
                {
                    return RedirectToLocal("/Partner/Index/");
                }
                else if (User.IsInRole("EndUser"))
                {
                    ApplicationDbContext db = new ApplicationDbContext();
                // know the partner
                    int partnerID = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().PartnersTBLID;
                    return RedirectToLocal("/Partner/List/" + partnerID.ToString());
                }
               
            }
            else
            {
                return RedirectToLocal(returnUrl);
            }
        }
