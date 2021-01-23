    var result = tests.GroupBy(t => new { t.TestName, t.SampleSize },
                (k, v) => new 
                { 
                   SampleSize = k.SampleSize, 
                   TestName = k.TestName, 
                   Average = v.Average(t => t.Result) 
                });
