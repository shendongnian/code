    return _db.ObjectSet.Where(p => DateTime.Now >= EntityFunctions.AddDays(p.ViewDate, -14))
            .GroupBy(y => y.PostID, y => y.ViewDate, (ID, Date) => new ExampleViewModel
            {
                Post_ID = ID,
                View_Date = Date.Count(),
                Title = _db.Posts.Find(ID)
            }).OrderByDescending(z => z.View_Date).Take(5);
