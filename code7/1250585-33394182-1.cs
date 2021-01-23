    public static void AddRecord(object publisher)
    {
        arrayList.Add((publisher as delegate).GetInvocationList().Length);
    }
    
