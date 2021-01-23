    if (GridPosition != other.GridPosition)
    {
        if (F > other.F)
        {
            return 1;
        }
        if (F < other.F)
        {
            return -1;
        }
        /////////////////////////////////
        return 0;
        /////////////////////////////////
    }
