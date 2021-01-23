    List<A> aList = new List<A>(); // Assume this list is populated.
    var bList = new List<B>(aList.Count);
    for (int i = 0; i < aList.Count; ++i)
    {
        bList.Add(Transform(aList[i]));
        aList[i] = null;
    }
    // If aList is a local it will go out of scope and its remaining
    // memory will be freed. If it is not local, you must ensure that
    // all remaining references to it (if any) are set to null.
