    Table1.GroupBy(r=>r.SchemaName).Select(grp=>new myschemaobj
     {
      SchemaName = grp.Key,
      PropertyObjects = grp.Select(r=>new mypropobj
        {
          PropertyName = r.PropertyName,
          PropertyType = r.PropertyType
        })
      });
