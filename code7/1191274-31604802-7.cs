    public void ChangeList(List<string> list)
    {
       list.Add("World");
    }
    List<string> inList = new List<string>();
    inList.Add("Hello");
    ChangeList(inList);
