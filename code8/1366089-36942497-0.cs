    public static List<List<T>> ChunkList<T>(List<T> list, int nSize = 30)
    {
        List<List<T>> chunkedList = new List<List<T>>();
        for (var i = 0; i < list.Count; i += nSize)
        {
            chunkedList.Add(list.GetRange(i, Math.Min(nSize, list.Count - i)));
        }
        return chunkedList;
    }
