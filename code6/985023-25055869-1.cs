    private static void Main(string[] args)
    {
    var abc = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    var pqr = new[] { 12.11, 13.13, 14.12, 15.12, 16.14, 17.12, 18.21, 19.12 };
    var values = abc.Take(abc.Length - 1).ToDictionary(
        o => 0.5 + o,
        o => new[]
    {
        pqr.Skip(1).ToList()[o], 
        pqr.Take(pqr.Length - 1).ToList()[o]
    }.Average());
    abc.ToList().ForEach(o => values.Add(o, pqr[o]));
