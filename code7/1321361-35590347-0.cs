    public IEnumerable<Mother> GetOrderedMothersByChildren(
        IEnumerable<Mother> mothers, IEnumerable<Child> children)
    {
        foreach (var child in children)
        {
            var mother = mothers.FirstOrDefault(m => m.Child == child);
            if (mother != null)
                yield return mother;
        }
    }
    //Usage
    var orderedMothers = GetOrderedMothersByChildren(mothers, children).ToList();
