    static Systemuser getSomething(String lastAllocation)
    {
        IEnumerator<KeyValuePair<String, Systemuser>> enumerator = Users.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current.Key.Equals(lastAllocation))
            {
                enumerator.MoveNext();
                enumerator.Current; // null if not another
            }
        }
        return null;
    }
