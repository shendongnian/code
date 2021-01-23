    public static TimeSpan Sum(this IEnumerable<TimeSpan> source) {
        TimeSpan sum = new TimeSpan(0, 0, 0);
        foreach (TimeSpan v in source) {
            sum = sum.Add(v);
        }
        return sum;
    }
