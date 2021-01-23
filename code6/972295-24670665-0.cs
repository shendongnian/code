    public static int FindNextPointerIndex(int oldIndex, string oldPointer, ...)
    {
        for(int i = oldIndex + 1; i < collection.Count ; i++)
        {
            if(collection[i].DateDetails != oldPointer) return i;
        }
        return -1;
    }
