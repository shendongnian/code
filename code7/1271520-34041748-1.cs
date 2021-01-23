    // test data
    var lenders = new Lender[] { 
    	new Lender { Name="Alice", Rate=0.2, Available=5 },
    	new Lender { Name="Bob", Rate=0.2, Available=10 },
    	new Lender { Name="Charlie", Rate=0.5, Available=20 },
    };
    var bestRate = lenders
    	.GroupBy(x => x.Rate)
    	.Select(g => new { Rate = g.Key, Sum = g.Sum(x => x.Available) })
    	.Where(g => g.Sum > 0)
    	.OrderBy(g => g.Rate)
    	.First();
  	Console.WriteLine("{0}, {1}", bestRate.Rate, bestRate.Sum);
