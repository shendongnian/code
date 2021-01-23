    Id(x => x.Id, m =>
    {
        m.Column("id");
    
        m.Generator(Generators.Native, g => g.Params(new
        {
            // generator-specific options
        }));
    
        m.Length(10);
        m.Type(new Int32Type());
        m.Access(Accessor.Field);
    });
