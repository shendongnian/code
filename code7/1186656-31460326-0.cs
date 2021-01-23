      // build sample data
      var list = Enumerable.Range(0, 10)
        .ToList()
        .Select(x => new {
          Date = DateTime.Now.AddMinutes(x),
          P1 = new Decimal(x),
          P2 = new Decimal(x + 1),
          P3 = new Decimal(x + 2)
        })
        .ToList();
      // list partionned by date; assumes that Date is unique in list
      List<Dictionary<DateTime, Decimal>> partitionedList;
      if (list.Count == 0) {
        partitionedList = new List<Dictionary<DateTime, Decimal>>();
      } else {
        var n = 3;
        var listElementType = list[0].GetType();
        partitionedList = Enumerable.Range(1, n)
          .Select(x => {
            var prop = listElementType.GetProperty("P" + x);
            var pList = list.ToDictionary(
              ll => ll.Date,
              ll => (Decimal)prop.GetValue(ll));
            return pList;
          })
          .ToList();
      }
