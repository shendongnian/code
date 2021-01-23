    KeyValuePair<String, Systemuser> getSomething(String lastAllocation)
    {
        IEnumerator<KeyValuePair<String, Systemuser>> enumerator = Users.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current.Key == lastAllocation)
            {
                enumerator.MoveNext();
                return enumerator.Current; // null if not another
            }
        }
        return null;
    }
