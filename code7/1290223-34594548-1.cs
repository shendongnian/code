    //Get All Id's and Created Date string values
    var idAndDates = yourDbContext.Posts
                            .Select(g => new { Id = g.Id, Created = g.CreatedDate}).ToList();
    //Convert the string to DateTime and use that to check the condition,
    //  Get the Id's of the Records which passed the condition
    var postIds = idAndDates
               .Where(g => DateTime.Parse(g.Created) > new DateTime(2015, 2, 3))
               .Select(x => x.Id);
    // Query the table again for records matching the Id's we got in previous step.
    var filterdPosts= yourDbContext.Posts.Where(x => postIds.Contains(x.Id)).ToList();
