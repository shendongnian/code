    var result = Userlist.GroupBy(x => new { x.ID, x.UserName })
                         .Select(x => new
                             {
                                ID = x.Key.ID,
                                UserName = x.Key.UserName,
                                BookType = x.Select(z => z.BookType).Distinct().Count(),
                                BookId = x.Select(z => z.BookId).Distinct().Count()
                             });
