    public static IEnumerable<string> DifferenceErrors(List<double> list1, List<double> list2)
    {
        // I recommend defining a minimum difference below which you consider the values to be identical:
        const double EPSILON = 0.00001;
        for (int i = 0; i < list1.Count; ++i)
            if (Math.Abs(list1[i] - list2[i]) >= EPSILON)
                yield return $"At index {i}, list1 has value {list1[i]} and list2 has value {list2[i]}";
    }
