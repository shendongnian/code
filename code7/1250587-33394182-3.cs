    public static void AddRecord(object publisher)
    {
        arrayList.Add((publisher as Delegate).GetInvocationList().Length);
    }
    
