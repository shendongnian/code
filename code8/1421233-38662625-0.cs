    var taxBands = new[]
    {
        new { Lower = 0m, Upper = 10999m, Rate = 0.0m },
        new { Lower = 11000m, Upper = 43000m, Rate = 0.2m },
        new { Lower = 43001m, Upper = 150000m, Rate = 0.4m },
        new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
    };
    
    var salary = 200000m; // however you get the salary figure
    
    var taxToBePaid = 0m;
    
    foreach (var band in taxBands)
    {
        if(salary > band.Lower)
        {
            var taxableAtThisRate = Math.Min(band.Upper - band.Lower, salary - band.Lower);
            var taxThisBand = taxableAtThisRate * band.Rate;
            taxToBePaid += taxThisBand;
        }
    }
    
    Console.WriteLine(taxToBePaid); // or do whatever you want here
