    List<Entry> ResultList = new List<Entry>();
    ResultList.Add(minMaxList[0]);
    foreach (Entry item in minMaxList)
    {
        if (item.getMax() >= ResultList[0].getMax())
        {
            if (item.getMax() != ResultList[0].getMax())
            {
                ResultList.Clear();
            }
            ResultList.Add(item);
        }
    }
