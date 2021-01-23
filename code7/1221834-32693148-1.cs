    var list = ctx.Web.Lists.GetByTitle(listTitle);
    var fields = list.Fields;
    ctx.Load(fields);
    ctx.ExecuteQuery();
    foreach (var field in fields)
    {
        if (field.FieldTypeKind != FieldType.Invalid)
        {
             var fieldValueType = field.GetFieldValueType();
             Console.WriteLine("{0} : {1}", field.InternalName, fieldValueType);    
        }        
    }
