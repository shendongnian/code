    var data = new[] {
                    new { Date = "01/07", Price = 10 },
                    new { Date = "02/07", Price = 20 },
                    new { Date = "", Price = 30 },
                    new { Date = "03/07", Price = 40 }
                };
    
    var noBlanks = (from d in data 
                    where !string.IsNullOrWhiteSpace(d.Date) 
                    select d).ToArray();
