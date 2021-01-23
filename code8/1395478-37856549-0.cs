    static double IntersectionSize(string a, string b) {
        var wordsA = a.Split(null);
        var wordsB = b.Split(null);
        var common = wordsA.Intersect(wordsB);
        double res = common.Sum(w => w.Length); // Total length of common words
        return 2 * res / (wordsA.Sum(w => w.Length) + wordsB.Sum(w => w.Length));
    }
