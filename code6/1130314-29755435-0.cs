    public static void LoadParameter<T>(T parameter, string name, SqlCommand cmd)
    {
        if (parameter != null && !string.Empty.Equals(parameter))
            cmd.Parameters.AddWithValue(name, parameter);
        else
            cmd.Parameters.AddWithValue(name, DBNull.Value);
    }
