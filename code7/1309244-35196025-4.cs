    public static bool AnyColumnTrue(this IEnumerable<IList<bool>> bools) 
    {
        if (bools == null) throw new ArgumentNullException("bools");
        return Enumerable.Range(0, bools.Min(seq => seq.Count))
            .Any(ix => bools.All(arr => arr[ix]));
    }
