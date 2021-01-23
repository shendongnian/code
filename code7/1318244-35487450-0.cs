    static void Set<T>(dynamic obj, string property, T value) {
        foreach (var field in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)) {
            var fieldValue = field.GetValue(obj);
    
            if (field.FieldType.GetInterface("System.Collections.IEnumerable") != null && !(fieldValue is string) && fieldValue != null) 
                foreach (var item in fieldValue) Set<T>(item, property, value);
            else if (field.Name == property) field.SetValue(obj, value);
        }
    }
