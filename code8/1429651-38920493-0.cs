    public MyForm(T context, string tableName)
    {
         ObjectContext objectContext = ((IObjectContextAdapter)breezeContext).ObjectContext;
         var items= objectContext.MetadataWorkspace.GetItems(System.Data.Entity.Core.Metadata.Edm.DataSpace.CSpace).Where(b => b.BuiltInTypeKind == BuiltInTypeKind.EntityType).ToList();
         var dbSetPropertyType = breezeContext.GetType().GetProperties().FirstOrDefault(x => x.Name == tablename);// tablename must match with the DbSet property in your context
         var dbset = breezeContext.Set(dbSetPropertyType.PropertyType.GenericTypeArguments.FirstOrDefault());
        bindingSource.DataSource = dbset;
        dgvDataviewer.DataSource  = bindingSource;
    }
