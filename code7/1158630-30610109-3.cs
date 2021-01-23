    public static implicit operator SqlDateTime(DateTime value)
    {
        return new SqlDateTime(value);
    }
    // SqlDateTime mySqlDate = DateTime.Now
