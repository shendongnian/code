    class DataImport<T> : DataBaseClass where T : IDataEntity, new()
    {
        public void WriteTableName(T arg)
        {
            string x = ((IDataEntity)arg).tableName;
            Console.WriteLine(x);
        }
    }
