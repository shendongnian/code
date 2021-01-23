    select new DataClass
    {
        Firstname = u.Firstname,
        Lastname = u.Lastname,
        ProfilePicPath = p.ProfilePicPath,
        Comment = c.Comment,
        CommentDate = c.CommentDate
    };
