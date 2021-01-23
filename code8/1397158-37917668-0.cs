    public static void DuplicateItem<T>(T dataBaseItem, T origionalItem)
        {
            var type = origionalItem.GetType();
            var properties = type.GetProperties();
            var databasePropertyInfo = dataBaseItem.GetType();
            foreach (var origionalProperty in properties)
            {
                var n = origionalProperty.Name;
                var databaseProperty = databasePropertyInfo.GetProperty(origionalProperty.Name);
                if(IsComplex(origionalProperty.GetValue(origionalItem,null)))
                    continue;
                if (IsCollection(origionalProperty.GetValue(origionalItem, null)))
                {
                    ClearItems(databaseProperty.GetValue(dataBaseItem,null), 
                        origionalProperty.GetValue(origionalItem, null));
                    continue;
                }
                var origionalValue = origionalProperty.GetValue(origionalItem, null);
                var t = Nullable.GetUnderlyingType(origionalProperty.PropertyType) 
                    ?? origionalProperty.PropertyType;
                var saveValue = (origionalValue == null) ? null : Convert.ChangeType(origionalValue, t);
                databaseProperty.SetValue(dataBaseItem, saveValue);
            }
        }
