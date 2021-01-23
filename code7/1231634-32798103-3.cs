    var query2 = db.Ratings;
    foreach (var rating in query2)
    {
        Debug.WriteLine(rating.name);
        foreach (var comment in rating.Comments)
        {
            Debug.WriteLine(comment.name);
            Debug.WriteLine(comment.User.name);
        }
    }
