    // database oriented query 
    var query = from user in chatDBContext.tbl_User
                select user;
    
    // take objects in memory THEN retrieve images
    var objects = query.ToList().Select(user => new
    {
        user.FirstName, user.LastName, user.Gender, user.Email,
        user.DoB, user.Address, user.City, user.State,
        user.Quote, user.username, image = plugins.LoadImage(user.Image)
    });
