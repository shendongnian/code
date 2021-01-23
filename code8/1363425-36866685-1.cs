    List<Item> groupedList = fullListOfItems
                                .GroupBy(l => l.ItemName)
                                .Select(i =>
                                    new Item()
                                    {
                                        ItemName = i.Key,
                                        ItemColor = i.First().ItemColor,
                                        SomethingElse = i.First().SomethingElse,
                                        Amount = i.Sum(k => k.Amount)
                                    }
                                ).ToList();
