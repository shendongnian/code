    int sumMax = 10000;
    var group = from n in nutrition
        group n by new { n.Operation, n.BatchId } into g
        select new { BatchId = g.Key.BatchId, 
            Operation = g.Key.Operation, 
            RateSum = g.ToList().Sum(nn => nn.NutritionRate), 
            RateSumMax = g.ToList().Sum(nn => nn.NutritionRate) > sumMax ? sumMax : g.ToList().Sum(nn => nn.NutritionRate), 
            RateMax = g.ToList().Max(nn => nn.NutritionRate) };
    var result = from g in group
        select new {
            BatchId = g.BatchId,
            Operation = g.Operation,
            Rate = g.Operation == 1 ? g.RateSumMax :
                   g.Operation == 2 ? g.RateMax :
                   g.RateSum //default is operaton 0
        };
    var totalRate = result.Sum(g=>g.Rate);
