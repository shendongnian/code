    public static class ALternatingListTestingExtensions
    {
        public static bool IsAlternating(this List<double> list)
        {
            var diffs = list.Zip(list.Skip(1), (a,b) => b - a);
            var signChanges = diffs.Zip(diffs.Skip(1), (a,b) => a * b < 0);
            return signChanges.All();
        }
    }
    
