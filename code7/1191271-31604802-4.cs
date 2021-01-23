    public void RetargetReference(ref List<string> originalList)
    {
        originalList = new List<string>();
        originalList.Add("World");
    }
    List<string> inList = new List<string>();
    inList.Add("Hello");
    RetargetReference(ref inList);
