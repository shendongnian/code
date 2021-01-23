    List<Entry> ResultList = new List<Entry>();
    foreach (Entry item in minMaxList)
    {
        if (ResultList.Count == 0 || item.getMax()> ResultList.First().getMax())
        {
            ResultList.Clear();
            ResultList.Add(item);
        }
        else if (item.getMax() == ResultList.First().getMax())
        {
            ResultList.Add(item);
        }
    }
