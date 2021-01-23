    public string Name;
    public long Number;
}
    using (SqlDataReader dataReader = command.ExecuteReader())
    {
        MyObject o = new MyObject()
        while (dataReader.Read())
        {
            o.Name= dataReader.GetString(0);
            o.Number = dataReader.GetInt32(1); // safe implicitly cast no need to make it manually
        }
    }
