            var aggregateValues = timeValues
                .GroupBy(k => k.When.Second >= 30
                    ? k.When.AddSeconds(-k.When.Second + 30)
                    : k.When.AddSeconds(-k.When.Second), k => k)
                .Select(group =>
                {
                    var tv = new TimeValues() { When = group.Key };
                    var values = new List<int>(3);
                    for (int index = 0; index < 3; index++)
                    {
                        values.Add(group.Average(t => t.Values[index]));
                    }
                    tv.Values = values.ToImmutableArray();
                    return values;
                });
