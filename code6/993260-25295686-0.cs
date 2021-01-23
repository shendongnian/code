    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        // Call the public method. The body of this method wasn't even valid before,
        // as it was calling `people.GetEnumerator() but not returning anything.
        return GetEnumerator();
    }
    public IEnumerator<Person> GetEnumerator()
    {
        return people.GetEnumerator();
    }
