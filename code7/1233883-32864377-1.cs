    var result = Userlist.GroupBy(x => new { x.ID, x.UserName })
                         .Select(x => new
                                     {
                                         ID = x.Key.ID,
                                         UserName = x.Key.UserName,
                                         BookType = x.Max(z => z.BookType),
                                         BookId = x.Max(z => z.BookId)
                                     });
