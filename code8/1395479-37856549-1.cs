    static double IntersectionSize(string a, string b) {
        var wordsA = a.Split(null);
        var wordsB = b.Split(null);
        if (wordsA.Length == 0 || wordsB.Length == 0) {
            // Avoid division by zero on return
            return 0;
        }
        var common = wordsA.Intersect(wordsB);
        double res = common.Sum(w => w.Length); // Total length of common words
        return 2 * res / (wordsA.Distinct().Sum(w => w.Length) + wordsB.Distinct().Sum(w => w.Length));
    }
