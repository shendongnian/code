    var maxTotal = 1500; //for you 8000
            var objects = new List<Item>()
                          {
                              new Item() {Score = 10, Price = 100},
                              new Item() {Score = 20, Price = 800},
                              new Item() {Score = 40, Price = 600},
                              new Item() {Score = 5, Price = 300},
                          };
            decimal runningTotal = 0;
            var newList = objects
                .OrderByDescending(p => p.Score)
                .Select(p =>
                        {
                            runningTotal = runningTotal + p.Price;
                            return new ItemWithRunningTotal()
                                   {
                                       Item = p,
                                       RunningTotal = runningTotal
                                   };
                        })
                .OrderByDescending(p => p.RunningTotal)
                .Where(p => p.RunningTotal <= maxTotal).Take(15);
            
