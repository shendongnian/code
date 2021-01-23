    static void RotateList<T>(IList<T> list, int places)
    {
        // circular.. Do Nothing
        if (places % list.Count == 0)
            return;
        T[] copy = new T[list.Count];
        list.CopyTo(copy, 0);
        for (int i = 0; i < list.Count; i++)
        {
            // % used to handle circular indexes and places > count case
            int index = (i + places) % list.Count;
            list[i] = copy[index];
        }
    }
