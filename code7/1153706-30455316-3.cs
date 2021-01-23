    // Your data
    IEnumerable<object> addedEntities = new object[] { new MyClass(), new MyClass() };
    object model = new MyClass();
    // The needed code
    Type type = model.GetType();
    MethodInfo method = typeof(DynamicLinqExtensions)
              .GetMethod("FilterByUniqueProp2")
              .MakeGenericMethod(type);
    method.Invoke(null, new object[] { addedEntities, model });
