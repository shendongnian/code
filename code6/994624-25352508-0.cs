    int id = workItemId;
    IPendingChangesExt service = serviceProvider.GetService<IPendingChangesExt>();
    FieldInfo field = service.GetType().GetField("m_workItemsSection", BindingFlags.Instance | BindingFlags.NonPublic);
    Type fieldType = field.FieldType;
    object value = field.GetValue(service);
    MethodInfo method = fieldType.GetMethod("AddWorkItemById", BindingFlags.Instance | BindingFlags.NonPublic);
    object[] objArray = new object[] { id };
    method.Invoke(value, objArray);
    
