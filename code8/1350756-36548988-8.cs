       protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                string schema = ServiceSettingsDictionary.GetSchemaName();
                if (!string.IsNullOrEmpty(schema))
                {
                    modelBuilder.HasDefaultSchema(schema);
                }
    
                modelBuilder.Conventions.Add(
                    new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                        "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
            }
