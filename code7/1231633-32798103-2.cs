    var query1 = from rating in db.Ratings
                    join comment in db.Comments
                        on rating.ID equals comment.RatingID
                    join user in db.Users
                        on comment.UserID equals user.ID
                    group new { comment, user } by rating into g
                    select new { g.Key, l = g.ToList() };
    foreach (var row in query1)
    {
        // you get rows grouped by rating
        Debug.WriteLine(row.Key.ID); // rating.ID
        // and a list of comments/users per rating
        foreach (var g in row.l)
        {
            Debug.WriteLine(g.comment.ID);
            Debug.WriteLine(g.user.ID);
        }
    }
