     class DatabaseParser : IObjectParser {
         public object Parse(object obj, propertyName string) {
             return ExecuteQuery(
                --Note the potential for SQL injection
                string.Format("SELECT {1} FROM {0} WHERE Id = @id", obj.GetType().Name, propertyName),
                ((dynamic)o).Id
             );           
         }
     }
     object parsedValue = new DatabaseParser(new MyClass(), "columnName");
