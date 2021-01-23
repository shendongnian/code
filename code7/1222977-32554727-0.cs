    private byte data;
    public void SetBit(int index, bool value)
    {
        if (value)
            data = (byte)(data | (1 << index));
        else
            data = (byte)(data & ~(1 << index));
    }
    public bool GetBit(int index)
    {
        return ((data & (1 << index)) != 0);
    }
