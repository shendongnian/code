    public static T? GetGreatestOrDefault<T>(IEnumerable<T?> values) where T : struct
            {
                return values.Where(v => v.HasValue)
                    .Select(v => v.Value)
                    .OrderByDescending(o => o)
                    .FirstOrDefault();
            }
