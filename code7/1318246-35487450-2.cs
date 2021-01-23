    static void Set<T>(dynamic obj, string property, T value) {
        //Iterate through the fields on your object.  Can change this to properties or do both.
        foreach (var field in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)) {
            var fieldValue = field.GetValue(obj);
    
            //If we have a collection, then iterate through its elements.
            if (field.FieldType.GetInterface("System.Collections.IEnumerable") != null && !(fieldValue is string) && fieldValue != null)
                foreach (var item in fieldValue) SetField<T>(item, property, value);
            //If field name and type matches, then set.  
            else if (field.Name == property && field.FieldType == typeof(T)) field.SetValue(obj, value);
        }
    }
