    var values = intermediateValues
                //.GroupBy(x => new {x.Rate, x.ExpiryDate })
                .GroupBy(r => new { Rate = ((int)(r.Rate / BucketSize) ) * BucketSize,ExpiryDate1 = r.ExpiryDate })
                .Select(y => new FXOptionScatterplotValue
                {
                    Volume = y.Sum(z => z.TransactionType == "TERMINATION" ? -z.Volume : z.Volume),
                    Rate = y.Key.Rate,
                    ExpiryDate = y.Key.ExpiryDate1,
                    Count = y.Count()
                }).ToArray();
