    var newList = data.GroupBy(x => new { x.Symbol })
    .Select
    (
        x =>
        {
            var subList = x.OrderBy(y => y.Date).ToList();
            return subList.Select((y, idx) => { //return is a function not an object
                var p = (idx < 1) ? null : subList.Skip(idx - 1).Take(2).Select(o => o.Close).ToList(); //your p
    
                return new //this return returns the object definition
                {
                    Symbol = y.Symbol,
                    Close = y.Close,
                    Date = y.Date,
                    Vol = p == null ? 0 : new DescriptiveStatistics(subList.Skip(idx - 1).Take(2).Select(o => (double)o.Close / (double)subList.ElementAt(idx - 1).Close).ToList()).StandardDeviation,
                };
            });
        }
    )
    .SelectMany(x => x)
    .ToList();
