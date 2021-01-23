    public void Serialize<T>(IEnumerable<T> pList)
    {
        if (pList != null && pList.Any())
        {
            if (pList is IEnumerable<IEnumerable<T>>) //example: list of lists of strings
            {
                foreach (IEnumerable<T> list in pList)
                {
                    Serialize(list);
                }
            }
            else //write CSV line
                _content.AppendLine(string.Join(_seperator, pList.Select(x => ObjectToCsvString(x)).ToArray()));
        }
    }
