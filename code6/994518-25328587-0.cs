    public static SqlParameter AddNullSafe(this SqlParameterCollection parameters, SqlParameter value)
    {
        if (value != null)
        {
            if (value.Value == null)
            {
                value.Value = DBNull.Value;
            }
            return parameters.Add(value);
        }
        return null;
    }
