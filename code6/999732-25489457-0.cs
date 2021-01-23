    var sums = db.Test.Take(1)
        .Select(unused => new
        {
            sum1 = db.Test.Sum(x => x.Column1),
            sum2 = db.Test.Sum(x => x.Column2),
            sum3 = db.Test.Sum(x => x.Column3),
        })
        .First();
