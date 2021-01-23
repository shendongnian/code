    var test = new [,,,]
    {
        {
            {
                { 00, 01, 02 }, { 03, 04, 05 }, { 06, 07, 08 }
            },
            {
                { 09, 10, 11 }, { 12, 13, 14 }, { 15, 16, 17 }
            },
            {
                { 18, 19, 20 }, { 21, 22, 23 }, { 24, 25, 26 }
            }
        },
        {
            {
                { 27, 28, 29 }, { 30, 31, 32 }, { 33, 34, 35 }
            },
            {
                { 36, 37, 38 }, { 39, 40, 41 }, { 42, 43, 44 }
            },
            {
                { 45, 46, 47 }, { 48, 49, 50 }, { 51, 52, 53 }
            }
        }
    };
    Func<int, IEnumerable<int>, IEnumerable<int>> unwrapLinearIndex = (linidx, bounds) =>
        bounds.Select((b, i) => bounds.Take(i).Aggregate(linidx, (acc, bnd) => acc / bnd) % b);
    // Reverse() to enumerate innermost dimensions first
    var testBounds = new int[test.Rank].Select((_, d) => test.GetUpperBound(d) + 1).Reverse().ToArray();
    for (int i = 00; i < test.Length; i++)
    {
        var indexes = unwrapLinearIndex(i, testBounds).Reverse().ToArray();
        Console.Write($"{test.GetValue(indexes)} ");
    }
