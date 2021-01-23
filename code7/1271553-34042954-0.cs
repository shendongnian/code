    string LoginId = User.Identity.GetUserId();
    // Get the user relationship entity
    var userRelationship = (from u in db.UserRelationships
                           where u.Id == LoginId && u.Status == 1
                           select u).FirstOrDefault();
    // Get the second user, using the values in the user relationship entity
    var secondUser = db.Users.Find(userRelationship.SecondUserId);
    // Generate the view model
    var viewModel =  new UserViewModel()
                     {
                         Fname = userRelationship.Users.FirstName,
                         Lname = userRelationship.Users.LastName,
                         Gender = userRelationship.Users.Gender,
                         Id = userRelationship.Id,
                         CurrentCity = userRelationship.Users.CurrentCity
                     };
