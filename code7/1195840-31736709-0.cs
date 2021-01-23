    public class SqlSomethingDataAccess : ISomethingDataAccess
    {
        public List<T> LoadAll<T>(Func<IDataReader, T> transformer)
        {
            // ... Setup connection and command, etc ...
            var returnList = new List<T>();
            var reader = command.ExecuteReader();  // <- from setup steps above
            while(!reader.MoveNext())
            {
                returnList.Add(transformer(reader));
            }
            return returnList;
        }
    }
