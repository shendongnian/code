    bool ProcessData(RowCollection rowCollection)
    {
        foreach (var item in rowCollection)
        {
            if (item["Col"] > 0)
            {
                return false;
            }
            else
            {
                // Do your stuff.
            }
        }
        return true;
    }
