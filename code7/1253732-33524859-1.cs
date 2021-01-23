    var list = ctx.Web.Lists.GetByTitle("Contacts");
    ctx.Load(list, l => l.Fields);
    ctx.ExecuteQuery();
    //get all available fields in list
    var fieldNames = list.Fields
                     .Where(f => f.FieldTypeKind != FieldType.Computed && f.FieldTypeKind != FieldType.File && f.FieldTypeKind != FieldType.Recurrence && f.FieldTypeKind != FieldType.CrossProjectLink && f.FieldTypeKind != FieldType.AllDayEvent)
                     .Select(f => f.InternalName).ToList();
     //construct expression to retrieve all field values   
     var includes = fieldNames.Select(name => (Expression<Func<ListItemCollection, object>>) (icol => icol.Include(i => i[name])));
               
     var items = list.GetItems(CamlQuery.CreateAllItemsQuery());
     ctx.Load(items, includes.ToArray());
     ctx.ExecuteQuery();
