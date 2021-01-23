    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateUsers(UsersAccount UsersAccount)
    {
        if (ModelState.IsValid)
        {
            var email = UsersAccount.Email;
            // Checking up whether there is a user with the email.
            var CreateAnAccount = db.Users.FirstOrDefault(b => b.Email == email);
            if (CreateAnAccount == null)
            {
                var user = new User();
                user.Email = email;//email
                user.PassWordHash = UsersAccount.PassWordHash;//password
                user.Firstname = UsersAccount.Firstname;//firstname
                user.Lastname = UsersAccount.Lastname;//lastname
                user.PhoneNumber = UsersAccount.PhoneNumber;//phonenumber
                //true - False
                user.Newsletter = Convert.ToBoolean(UsersAccount.Newsletter);//newsletter
                //which some Fk users have chosen.
                user.fk_role = Convert.ToInt32(UsersAccount.Roles);// what's roles
                user.fk_package = 0;//package
                user.fk_sex = Convert.ToInt32(UsersAccount.Sexs);//sex
                user.fk_area = Convert.ToInt32(UsersAccount.Areas);//area
                user.fk_Professionals = Convert.ToInt32(UsersAccount.Professionals);//professional
                //age
                user.age = Convert.ToDateTime(UsersAccount.age);
                //img users
                user.img = "userimg.png";
                // Need to find out what role you have chosen,
                if (user.fk_role == 6)
                {
                    user.Approved = false;
                }
                else
                {
                    user.Approved = true;
                }
                // should just content into the database.
                db.Users.InsertOnSubmit(user);
                // must save the contents.
                db.SubmitChanges(); // save
                // send the person to the log in page.
            }
            else
            {
                //Fremviser en fejl besked hvis der findes en email.
                ViewBag.MessageError = "Denne brugere findes i vores system.";
            }
        }
        //return indhold til siden.
        return View();
    }
