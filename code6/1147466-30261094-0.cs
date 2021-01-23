    var query = list.GroupBy(x => new { x.Tag, x.Time.Date })
                    .Select(g => new NewPoint
                            {
                                Tag = g.Key.Tag,
                                Date = g.Key.Date,
                                LowValue = g.Min(x => x.Value),
                                HighValue = g.Max(x => x.Value),
                                AvgValue = (int) g.Average(x => x.Value)
                            });
