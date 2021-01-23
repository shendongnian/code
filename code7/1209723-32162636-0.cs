    static class Extensions
    {
        public static void Fill(this Array arr, Func<object> gen)
        {
            // Get the dimensions of the array
            var dims = Enumerable.Range(0, arr.Rank)
                .Select(arr.GetLength)
                .ToArray();
            Func<int, int, int> product = (i1, i2) => i1 * i2;
            for (var i = 0; i < arr.Length; i++)
            {
                var indices = dims.Select((d, n) => (i/dims.Take(n).Aggregate(1, product))%d).ToArray();
                arr.SetValue(gen(), indices);
            }
        }
    }
