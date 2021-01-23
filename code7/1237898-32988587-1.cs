        IEnumerable<ShareEntry> share = new List<ShareEntry>();
        IEnumerable<CommentEntry> comment = new List<CommentEntry>();
        var output = share
            .Select(x => new
        {
            id = x.ID,
            date = x.Date,
            type = "share"
        })
            .Concat(comment.
                Select(x => new
                {
                    id = x.ID,
                    date = x.Date,
                    type = "comment"
                }))
             .OrderByDescending(x => x.date).Take(10);
