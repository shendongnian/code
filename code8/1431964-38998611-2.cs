    List<Part> Model = new List<Part>
    {
        new Part{ ScanTime = new DateTime(2016,1,1,1,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,4,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,4,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,4,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,4,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,7,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,12, 0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,17,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,19,0,0) },
        new Part{ ScanTime = new DateTime(2016,1,1,23,0,0) },
    };
    var shiftChangeTime = new TimeSpan(12, 0, 0);
    var result = Model.GroupBy(x => x.ScanTime.TimeOfDay < shiftChangeTime ? "Day" : "Night")
         .Select(g => new
         {
             Shift = g.Key,
             Average = g.GroupBy(item => item.ScanTime.Hour, 
                                 (key, group) => new { Hour = key, Amount = group.Count() })
                        .Average(y => y.Amount)
         }).ToList();
