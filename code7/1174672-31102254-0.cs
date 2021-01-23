      //Setting up the mock data
      List<List<int>> data = new List<List<int>>();
      data.Add(new List<int>(new[] { 1, 3 }));
      data.Add(new List<int>(new[] { -1, -3 }));
      data.Add(new List<int>(new[] { 2, 5 }));
      data.Add(new List<int>(new[] { -2, -5 }));
      data.Add(new List<int>(new[] { -3, 4 }));
      data.Add(new List<int>(new[] { -5, 4 }));
      data.Add(new List<int>(new[] { 3, 5, -4 }));
      data.Add(new List<int>(new[] { 6, -8 }));
      data.Add(new List<int>(new[] { 7, -8 }));
      data.Add(new List<int>(new[] { -6, -7, 8 }));
      data.Add(new List<int>(new[] { 7, 9 }));
      data.Add(new List<int>(new[] { -7, -9 }));
      data.Add(new List<int>(new[] { 3, 8, -10 }));
      data.Add(new List<int>(new[] { -3, -8, -10 }));
      data.Add(new List<int>(new[] { -3, 8, 10 }));
      data.Add(new List<int>(new[] { 3, -8, 10 }));
      data.Add(new List<int>(new[] { 4, 9, -11 }));
      data.Add(new List<int>(new[] { -4, -9, -11 }));
      data.Add(new List<int>(new[] { -4, 9, 11 }));
      data.Add(new List<int>(new[] { 4, -9, 11 }));
      data.Add(new List<int>(new[] { 10, 11 }));
      data.Add(new List<int>(new[] { -1, 6 }));
      data.Add(new List<int>(new[] { 1, -6 }));
      data.Add(new List<int>(new[] { -2, 7 }));
      data.Add(new List<int>(new[] { 2, 39 }));
      //Actual solution code
      var all = data.SelectMany(l => l); //flatten
      var grouped = all.GroupBy(g => Math.Abs(g)); //Group
      //Look for groups where the Sum is equal Key * Count, 
      //which means only either all positives, or all negatives
      var good = grouped.Where(i => i.Key * i.Count() == Math.Abs(i.Sum())); 
      var result = good.Select(g => g.First()); //Get rid of groups
      var allPos = result.Where(i => i > 0); //Self explanatory
      var allNeg = result.Where(i => i < 0);
