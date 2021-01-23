    var itemType = itemRet.ortype;
    var typeTest = itemRet.Type;
    QuickbooksItem qbItem = new QuickbooksItem();
    PropertyInfo ListIdProperty = typeTest.GetProperty("ListID");
    MethodInfo ListValueMethod = ListIdProperty.GetMethod("GetValue");
    qbItem.Id = (int)ListValueMethod.Invoke(ListIdProperty.GetValue(itemRet, null), null);
