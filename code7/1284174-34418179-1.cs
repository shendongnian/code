    {
        bool first = true;
        int high = 0;
        int low = 0;
        foreach(int item in items)
        {
            if (first)
            {
                high = item;
                low = item;
            }
            else if (item == low - 1)
            {
                low = item;
            }
            else
            {
                yield return new MyRange(high, low);
                high = item;
                low = item;
            }
        }
