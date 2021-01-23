    public static explicit operator DateTime(SqlDateTime x)
    {
        return SqlDateTime.ToDateTime(x);
    }
    public static implicit operator SqlDateTime(DateTime value)
    {
        return new SqlDateTime(value);
    }
