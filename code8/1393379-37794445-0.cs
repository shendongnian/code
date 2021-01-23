    list.Sort(delegate(Member  x, Member y)
    {
        // Sort by total in descending order
        int a = y.Total.CompareTo(x.Total);
        // Both Member has the same total.
        // Sort by name in ascending order
        a = x.Name.CompareTo(y.Name);
        return a;
    });
