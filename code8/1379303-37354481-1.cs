    public static void DisplayProperties(object objectA, string objName="")
    {
        if (objectA != null)
        {
            Type objectType;
            objectType = objectA.GetType();
            foreach (PropertyInfo propertyInfo in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead))
            {
                object valueA = propertyInfo.GetValue(objectA, null);
                if (typeof(IComparable).IsAssignableFrom(propertyInfo.PropertyType) || propertyInfo.PropertyType.IsPrimitive || propertyInfo.PropertyType.IsValueType)
                {
                    Console.WriteLine(objName +  (objName==""? "" : ".") + propertyInfo.ReflectedType.Name + "." + propertyInfo.Name);
                }
                else
                    DisplayProperties(valueA, objName + (objName == "" ? "" : ".") + objectType.Name);
            }
        }
    }
