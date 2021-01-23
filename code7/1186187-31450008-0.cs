      var ListbrandList = new List<String>() {
        "Cola",
        "Juice",
        "Cola",
        "Water",
        "Milk",
        "Water",
        "Cola",
      };
      var result = ListbrandList
        .GroupBy(item => item)
        .Select(item => new {
             Name = item.Key,
             Count = item.Count()
           })
        .OrderByDescending(item => item.Count)
        .ThenBy(item => item.Name);
      String report = String.Join(Environment.NewLine, result
        .Select(item => String.Format("{0} appears {1} time(s)", item.Name, item.Count)));
