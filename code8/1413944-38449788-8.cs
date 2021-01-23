    static void ShiftList<T>(IList<T> list, int places)
    {
        // circular.. Do Nothing
        if (places % list.Count == 0)
            return;
        T[] copy = new T[list.Count];
        list.CopyTo(copy, 0);
        for (int i = 0; i < list.Count; i++)
        {
            int index = (i + places) % list.Count;
            list[index] = copy[i];
        }
    }
