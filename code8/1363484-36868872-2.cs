    List<JoinModel> lstJoinModel = Context.Books.GroupJoin(Context.BookOrder,
                                   bk => new { bk.UniqueID, bk.Year, bk.BookNumber },
                                   bko => new { bko.UniqueID, bko.Year, bko.BookNumber },
                                   (x, y) => new { Book = x, BookOrder = y })
                                   .SelectMany(x => x.BookOrder.DefaultIfEmpty(),
                                   (x, y) => new JoinModel
                                   {
                                       Book = x.Book,
                                       BookOrder = y
                                   })
                                  .Where(r => r.Book.Value > 0).ToList();
