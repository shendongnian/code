    public static class DataExtensions
    {
        public static T ToEntity<T>(this DataRow dr) where T : new()
        {
          DataColumnCollection columns = dr.Table.Columns;
          T obj1 = new T();
          foreach (PropertyInfo propertyInfo in obj1.GetType().GetProperties())
          {
            if (columns.Contains(propertyInfo.Name) && dr[propertyInfo.Name] != DBNull.Value)
            {
              if (propertyInfo.PropertyType.IsGenericType)
              {
                object obj2 = Convert.ChangeType(dr[propertyInfo.Name], propertyInfo.PropertyType.GetGenericArguments()[0]);
                propertyInfo.SetValue((object) obj1, obj2, (object[]) null);
              }
              else
              {
                object obj2 = Convert.ChangeType(dr[propertyInfo.Name], propertyInfo.PropertyType);
                propertyInfo.SetValue((object) obj1, obj2, (object[]) null);
              }
            }
          }
          return obj1;
        }
    
        public static List<T> ToList<T>(this DataTable dt) where T : new()
        {
          List<T> list = new List<T>();
          foreach (DataRow dr in (InternalDataCollectionBase) dt.Rows)
            list.Add(DataExtensions.ToEntity<T>(dr));
          return list;
        }
    }
