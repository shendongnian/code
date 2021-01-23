    Dictionary<float, MiniChannel[]> MatchingTimes = channel
              .SelectMany(c => c.times)
              .Distinct()
              .ToDictionary(k => k, v => channel
                            .Where(c => c.times.Contains(v))
                            .Select(c => new MiniChannel {
                                axis = c.axis,
                                value = c.values[Array.IndexOf(c.times, v)]
                            })
              .ToArray());
