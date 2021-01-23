    public static class Ex
    {
        public static TFieldType GetFieldValue<TFieldType, TObjectType>(this TObjectType obj, string fieldName)
        {
            var fieldInfo = typeof (TObjectType).GetField(fieldName);
            return (TFieldType) fieldInfo.GetValue(obj);
        }
    }
