    public static class MapperHelper
    {
        public static IEnumerable<T> DataReaderMapper<T>(this IDataReader dataReader, Func<IDataRecord, T> map)
        {
            while (dataReader.Read())
            {  
                yield return map(dataReader);
            }
        }
