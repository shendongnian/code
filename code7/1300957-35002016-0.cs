        AttributeToTableAnnotationConvention<SoftDeleteAttribute, string> conv =
           new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
              "SoftDeleteColumnName",
              (type, attributes) => attributes.Single().ColumnName);
                
        modelBuilder.Conventions.Add(conv);
        //this will dynamically add the attribute to all models
        modelBuilder.Types().Configure(delegate(ConventionTypeConfiguration i)
        {
            i.HasTableAnnotation("SoftDeleteColumnName", Entity.G etSoftDeleteColumnName());
        });
