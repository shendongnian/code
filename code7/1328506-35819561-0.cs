    public List<int> RemoveDuplicats(List<int> list)
    {
        int i = 0;
        List<int> distinctElements = new List<int>();
        while (i < list.Count)
        {
            if (!distinctElements.Contains(list[i]))
                distinctElements.Add(list[i]);
            i++;
        }
        return distinctElements;
    }
