    var TheQuery = MyDC.SomeTable
                .Where(s => s.ExpirationDate < DateTime.UtcNow)
                .Where(s => s.UserID == SomeParameter)                     
                .Select(v => new SomeModel
                {
                    BasketID = v.BasketID,
                    ExpirationDate = v.ExpirationDate,
                    SomeProp = v.SomeProp
                    //....
                })
                .GroupBy(s => s.BasketID)
                .Select(items => items.Where(item => item.SomeProp == 2 ||
                                                     item.SomeProp == 3 ||
                                                     item.SomeProp == 4).OrderByDescending(item => item.ExpirationDate).First()).ToList();
