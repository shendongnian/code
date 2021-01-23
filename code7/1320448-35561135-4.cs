    List<MyModel> TheExpiredFruits = (from b in MyDC.Fruits
                                      where b.ExpirationDate < DateTime.UtcNow
                                      group b by b.BasketID into fruits
                                      let fruit = fruits.OrderByDescending(f => f.ExpirationDate).First()
                                      select new MyModel()
                                      {
                                          BasketId = fruit.BasketID,
                                          Column1 = fruit.SomeColumn1,
                                          ColumnN = fruit.SomeColumnN,
                                      }).ToList();
