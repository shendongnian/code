       public static DataTable ClassToDataTable<T>() where T : class
        {
            Type classType = typeof(T);
            List<PropertyInfo> propertyList = classType.GetProperties().ToList();
            if (propertyList.Count < 1)
            {
                return new DataTable();
            }
            string className = classType.UnderlyingSystemType.Name;
            DataTable result = new DataTable(className);
            foreach (PropertyInfo property in propertyList)
            {
                DataColumn col = new DataColumn();
                col.ColumnName = property.Name;
                Type dataType = property.PropertyType;
                if (IsNullable(dataType))
                {
                    if (dataType.IsGenericType)
                    {
                        dataType = dataType.GenericTypeArguments.FirstOrDefault();
                    }
                }
                else
                {   // True by default
                    col.AllowDBNull = false;
                }
                col.DataType = dataType;
                result.Columns.Add(col);
            }
            return result;
        }
        public static DataTable ClassListToDataTable<T>(List<T> ClassList) where T : class
        {
            DataTable result = ClassToDataTable<T>();
            if (result.Columns.Count < 1)
            {
                return new DataTable();
            }
            if (ClassList.Count < 1)
            {
                return result;
            }
            foreach (T item in ClassList)
            {
                ClassToDataRow(ref result, item);
            }
            return result;
        }
        public static void ClassToDataRow<T>(ref DataTable Table, T Data) where T : class
        {
            Type classType = typeof(T);
            string className = classType.UnderlyingSystemType.Name;
            // Checks that the table name matches the name of the class. 
            // There is not required, and it may be desirable to disable this check.
            // Comment this out or add a boolean to the parameters to disable this check.
            if (!Table.TableName.Equals(className))
            {
                return;
            }
            DataRow row = Table.NewRow();
            List<PropertyInfo> propertyList = classType.GetProperties().ToList();
            foreach (PropertyInfo prop in propertyList)
            {
                if (Table.Columns.Contains(prop.Name))
                {
                    if (Table.Columns[prop.Name] != null)
                    {
                        row[prop.Name] = prop.GetValue(Data, null);
                    }
                }
            }
            Table.Rows.Add(row);
        }
        public static bool IsNullable(Type Input)
        {
            if (!Input.IsValueType) return true; // Is a ref-type, such as a class
            if (Nullable.GetUnderlyingType(Input) != null) return true; // Nullable
            return false; // Must be a value-type
        }
