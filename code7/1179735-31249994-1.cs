    public void Truncate(List<string> newsList, int length)
    {
        for (int i = 0; i < newsList.Count; i++)
        {
            newsList[i] = newsList[i].Substring(0, length);
        }
    }
