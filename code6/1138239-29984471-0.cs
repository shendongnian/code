    var durationsByMonth = from item in items
                           group item by item.FirstSeen.Month
                           into itemsByMonth
                           select new
                           {
                               Month = itemsByMonth.Key,
                               TotalDuration = itemsByMonth.Sum(i => i.Duration)
                           };
