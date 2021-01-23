        public static T DefaultMapper<T>(IDataRecord record) where T : class, new()
        {
            //This is now effectively inside the while loop,
            // but .Net caches the expensive recursive calls for you
            PropertyInfo[] PropertyInfo;
            var temp = typeof(T);
            PropertyInfo = temp.GetProperties();
            obj = new T();
            foreach (PropertyInfo prop in PropertyInfo)
            {
                if (DataConverterHelper.ColumnExists(dataReader,prop.Name) && !dataReader.IsDBNull(prop.Name))
                {
                    prop.SetValue(obj, dataReader[prop.Name], null);
                }
            }
            return obj;
        }
    }
