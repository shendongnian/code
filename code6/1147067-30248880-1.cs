    static systemuser getSomething(String lastAllocation)
    {
        IEnumerator<KeyValuePair<string, systemuser>> enumerator = Users.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current.Key == lastAllocation)
            {
                enumerator.MoveNext();
                enumerator.Current; // null if not another
            }
        }
        return null;
    }
