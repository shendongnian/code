    public IEnumerable<T> IntersectsNonEmpty<T>(
                              params IEnumerable<T>[] input)
    {
       var nonEmpty = input.Where(i => i.Any()).ToList();
       if (!nonEmpty.Any()) return false; //or whatever
       return nonEmpty.Aggregate((l1, l2) => l1.Intersect(l2));
    }
