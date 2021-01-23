    Dictionary<Type, int> ExceptionCounts;
    public void ExceptionSeen(Type type)
    {
        ExceptionCounts[type]++;
    }
