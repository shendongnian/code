    var properties = new List<string>();
    dynamic dynObject = new ExpandoObject();
    dynObject.Prop1 = "property value 1";
    dynObject.Prop2 = "property value 2";
    var provider = dynObject as IDynamicMetaObjectProvider;
    if (provider != null)
        properties.AddRange(provider.GetMetaObject(Expression.Constant(dynObject)).GetDynamicMemberNames());
    foreach (var prop in properties)
    {
        //do something
    }
