    public List<double> RollingAverage(List<int> source, int width)
    {
        return Enumerable.Range(0, 1 + numlist.Count - width).
                                  Select(i => numlist.Skip(i).Take(width).Average()).
                                  ToList();
    }
