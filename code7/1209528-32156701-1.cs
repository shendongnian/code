        var condition = "7";
        string lists = "1,2,3,4,5,6,7,7,8,9";
        var delimiter = new[] {','};
        var splitlist = lists.Split(delimiter,StringSplitOptions.RemoveEmptyEntries).ToList();
        var newList = new List<string>();
       foreach (var item in splitlist.Where(x => !x.Equals(condition)))
            {
                newList.Add(item);
            }
       OR
       var newList = splitlist.Where(x => !x.Equals(condition)).ToList();
