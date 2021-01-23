    public T CallMultipleRecordSetStoredProcedure<T>(
        params Expression<Func<T, IList>>[] recordSetPropertiesInOrder)
        where T : class, new()
    {
        var outputType = typeof (T);
        var output = new T();
        // DbConnection & Command setup hidden 
        var recordSetNumber = 0;
        do
        {
            var outputRecordSetPropertyName =
                ((MemberExpression) recordSetPropertiesInOrder[recordSetNumber].Body).Member.Name;
            var dtoList = (IList) outputType.GetProperty(outputRecordSetPropertyName).GetValue(output);
            var dtoListType = dtoList.GetType().GetGenericArguments()[0];
            while (reader.Read())
            {
                var item = Activator.CreateInstance(dtoListType);
                var propertiesToWrite = dtoListType.GetProperties().Where(p => p.CanWrite);
                foreach (var property in propertiesToWrite)
                {
                    property.SetValue(
                        item,
                        Convert.ChangeType(reader[property.Name], property.PropertyType));
                }
                dtoList.Add(item);
            }
            recordSetNumber++;
        } while (reader.NextResult());
        return output;
    }
