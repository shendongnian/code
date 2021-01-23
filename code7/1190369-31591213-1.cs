    var db = OpenDbConnection();
    
    db.DropAndCreateTable<TypeWithNullableEnum>();
    
    db.Insert(new TypeWithNullableEnum { Id = 1, 
        EnumValue = SomeEnum.Value1, NullableEnumValue = SomeEnum.Value2 });
    db.Insert(new TypeWithNullableEnum { Id = 2, EnumValue = SomeEnum.Value1 });
    
    var rows = db.Select<TypeWithNullableEnum>();
    Assert.That(rows.Count, Is.EqualTo(2));
    
    var row = rows.First(x => x.NullableEnumValue == null);
    Assert.That(row.Id, Is.EqualTo(2));
    
    var quotedTable = typeof(TypeWithNullableEnum).Name.SqlTable();
    rows = db.SqlList<TypeWithNullableEnum>("SELECT * FROM {0}".Fmt(quotedTable));
    
    row = rows.First(x => x.NullableEnumValue == null);
    Assert.That(row.Id, Is.EqualTo(2));
    
    rows = db.SqlList<TypeWithNullableEnum>("SELECT * FROM {0}"
        .Fmt(quotedTable), new { Id = 2 });
    
    row = rows.First(x => x.NullableEnumValue == null);
    Assert.That(row.Id, Is.EqualTo(2));
