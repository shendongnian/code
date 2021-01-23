    var orderDict = new Dictionary<string, int>{
          {"Eggs", 0},
          {"Milk", 1},
          {"Water", 2}
    }
    var sortedbyCat =data.List.GroupBy(c => c.ProdType).OrderBy(g => orderDict[g.Key]);
