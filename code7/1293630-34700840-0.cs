    public bool IsCompatible(VNodeClassID itemA, VNodeClassID itemB)
    {
        if (!Enum.IsDefined(typeof(VNodeClassID), itemA))
            return false;
        if (!Enum.IsDefined(typeof(VNodeClassID), itemB))
            return false;
        return validation[(int)itemA, (int)itemB];
    }
