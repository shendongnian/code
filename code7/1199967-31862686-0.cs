    // This is the current user that we're going to add info to
    var currentUser = FBSession.ActiveSession.User;
    // Specify that we want the First Name, Last Name and Locale that is connected to the user
    PropertySet parameters = new PropertySet();
    parameters.Add("fields", "locale,first_name,last_name");
    // Set Graph api path to get data about this user
    string path = "/me/";
    // Create the request to send to the Graph API, also specify the format we're expecting (In this case a json that can be parsed into FBUser)
    FBSingleValue sval = new FBSingleValue(path, parameters,
      new FBJsonClassFactory(FBUser.FromJson));
    // Do the actual request
    FBResult fbresult = await sval.Get();
    if (fbresult.Succeeded)
    {
      // Extract the FBUser with new data
      var extendedUser = ((FBUser)fbresult.Object);
      // Attach the newly fetched data to the current user
      currentUser.FirstName = extendedUser.FirstName;
      currentUser.LastName = extendedUser.LastName;
      currentUser.Locale= extendedUser.Locale;
    }
