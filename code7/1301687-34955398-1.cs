    private double AggregateDynamic<T>(IEnumerable<T> list, string propertyName, string func)
    {
        Func<T, double> propertyFunction = x => Convert.ToDouble(x.GetType().GetProperty(propertyName).GetValue(x, null));
        switch (func)
        {
            case "Sum":
                return list.Sum(propertyFunction);
            case "Average":
                return list.Average(propertyFunction);
            case "Count":
                return list.Count();
            case "Max":
                return list.Max(propertyFunction);
            default:
                throw new ArgumentException("Unknown aggregate function");
        }
    }
