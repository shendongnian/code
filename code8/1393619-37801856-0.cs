    for (int c = 0; c < dataReader.FieldCount; c++)
    {
        string name = dataReader.GetName(c);
        Type type = dataReader.GetFieldType(c);
    }
