    string[,] stats = new string[3,3] {
	  { "Name:", "userName", "some stat" },
	  { "More stat:", "more", "more" },
	  { "Even more:", "hey", "great" }
    };
    var lines = stats.Cast<string>()
                     .Select((v, i) => new { Idx = i, Val = v })
                     .GroupBy(x => x.Idx / stats.GetLength(1))
                     .Select(x => string.Join(" ", x.Select(y => y.Val)));
    Console.WriteLine(string.Join(Environment.NewLine, lines));
