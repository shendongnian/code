    public void CreateReference(out List<string> newList)
    {
        newList = new List<string>();
        newList.Add("Hello World");
    }
    List<string> list;
    CreateReference(out list);
