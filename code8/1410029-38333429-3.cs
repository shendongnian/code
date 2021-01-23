    public static implicit operator BlittableDateTime(DateTime value)
    {
        return new BlittableDateTime(value.ToFileTime());
    }
    public static implicit operator DateTime(BlittableDateTime value)
    {
        return DateTime.FromFileTime(value._ticks);
    }
