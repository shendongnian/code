    public bool CheckIntValue(int value)
    {
        return value < 0;
    }
    
    public void CheckIntNotLessThanZero(int value)
    {
        if (CheckIntValue(value))
            return;
    
        Console.WriteLine("Not less than zero!")
    }
