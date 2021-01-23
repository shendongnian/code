    public virtual Object GetFormat(Type formatType)
    {
        if (formatType == typeof (NumberFormatInfo))
        {
            return (NumberFormat);
        }
        if (formatType == typeof (DateTimeFormatInfo))
        {
            return (DateTimeFormat);
        }
        return (null);
    }
