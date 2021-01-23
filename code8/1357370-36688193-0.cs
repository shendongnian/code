    // First we need copies to operate on
    var firstCopy = new List<TypeOne>(firstList);
    var secondCopy = new List<TypeTwo>(secondList);
    // Now we iterate the first list once complete
    foreach (var typeOne in firstList)
    {
        var match = secondCopy.FirstOrDefault(s => s.baz == typeOne.foo);
        if (match == null)
        {
            // Item in first but not in second
        }
        else
        {
            // Match is duplicate and shall be removed from both
            firstCopy.Remove(typeOne);
            secondCopy.Remove(match);
        }
    }
