    public int MaxHealth
    {
        get
        {
            return Memory[Address].IsValid
                   ?   Memory[Address].Read<int>(Offs.Life.MaxHp)
                   :   0;
        }
    }
