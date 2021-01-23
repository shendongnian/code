    public int X()
    {
        var i = 1;
        {
            {
                i++;
                {
                    return i;
                }
            }
        }
    }
    public int Y()
    {
        var i = 1;
        i++;
        return i;
    }
