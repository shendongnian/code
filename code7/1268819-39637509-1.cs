     public ActionResult LoginRoute(string returnUrl)
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
                    int partnerID = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().PartnersTBLID;
                    return RedirectToLocal("/P/List/" + partnerID.ToString());
                }
                else
                {
                    return RedirectToLocal("/P/Index/3");
                }
            }
            else
            {
                return RedirectToLocal(returnUrl);
            }
        }
