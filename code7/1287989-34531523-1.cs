    public static class Ex
    {
        public static TFieldType GetFieldValue<TFieldType, TObjectType>(this TObjectType obj, string fieldName)
        {
            var fieldInfo = obj.GetType().GetField(fieldName,
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic);
            return (TFieldType)fieldInfo.GetValue(obj);
        }
    }
