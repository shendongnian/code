    static void ShiftList<T>(List<T> list, int places)
    {
        T[] copy = new T[list.Count];
        list.CopyTo(copy);
    
        for(int i = 0; i < list.Count; i++)
        {
            // to handle negative index and places > Count
            int index =  (i + places) % list.Count; 
    
            list[i] = copy[index];
        }
    }
