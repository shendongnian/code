    public static IEnumerable<FieldInfo> GetFields(Type classType)
            {
                var allFields = classType
                    .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
                var definedFields = from field in allFields
                                    where !field.IsDefined(typeof(CompilerGeneratedAttribute), false)
                                    select field;
    
                return definedFields;
            }
