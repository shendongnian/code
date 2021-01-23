    using FastDynamic;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Sample
    {
        public static class DataReaderExtensions
        {
            private static void SetPropertiesFromDataReader(IDataReader reader, object entity)
            {
                if (reader == null || entity == null) throw new ArgumentNullException();
                Type entityType = entity.GetType();
                var setters = entityType.GetSetters();
                for (int fieldIndex = 0; fieldIndex < reader.FieldCount; fieldIndex++)
                {
                    var fieldName = reader.GetName(fieldIndex);
                    Setter setter = null;
                    if (!string.IsNullOrEmpty(fieldName) && setters.TryGetValue(fieldName, out setter))
                    {
                        if (!reader.IsDBNull(fieldIndex))
                        {
                            setter(entity, reader.GetValue(i));
                        }
                    }
                }
            }
    
            public static IEnumerable<T> ToEnumberable<T>(this IDataReader reader) where T:class, new()
            {
                Type entityType = typeof(T);
                Func<object> activator = entityType.GetActivator();
                while (reader.Read())
                {
                    var entity = activator();
                    SetPropertiesFromDataReader(reader, entity);
                    yield return (T)entity;
                }
            }
    
            public T FirstOrDefault<T>(this IDataReader reader) where T : class, new()
            {
                return reader.ToEnumberable<T>().FirstOrDefault();
            }
    
            public List<T> ToList<T>(this IDataReader reader) where T : class, new()
            {
                return reader.ToEnumberable<T>().ToList();
            }
    
        }
    }
