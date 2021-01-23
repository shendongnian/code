    var Users = new List<User>
    {
        { UserID = 576, PostId = 7 },
        { UserID = 576, PostId = 4 },
        { UserID = 4, PostId = 2 },
        { UserID = 2, PostId = 5 },
        { UserID = 2, PostId = 1 },
        { UserID = 576, PostId = 9 }
    }
    var Ordered = Users
        .GroupBy(x => x.UserID)
        .Select(x => new
        {
            AuthorCount = x.Count(),
            Posts = x
        })
        .OrderByDescending(x => x.AuthorCount)
        .SelectMany(x => x.Posts)
        .ToList();
