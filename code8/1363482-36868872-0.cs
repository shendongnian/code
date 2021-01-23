            var result = (from bk in Context.Books
                          join bko in Context.BookOrders on new { bk.UniqueID, bk.Year, bk.BookNumber } equals new { bko.UniqueID, bko.Year, bko.BookNumber }
                          into bd
                          from bd2 in bd.DefaultIfEmpty()
                          where bk.Value > 0
                          select new JoinModel { Book = bk, BookOrder = bd2 }
                          ).ToList();
