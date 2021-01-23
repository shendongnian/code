    static void ShiftList<T>(List<T> list, int places)
    {
        var copy = list.ToList();
    
        for(int i = 0; i < list.Count; i++)
        {
            int index = i - 3;
            if (index < 0)
                index = list.Count + index;
    
            list[i] = copy[index];
        }
    }
