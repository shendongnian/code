 modelBuilder.Entity<Company>()
    .Reference(c => c.Status)
    .InverseCollection()
    .ForeignKey(cs => cs.StatusId);
2. If you don't want StatusId in the CLR type, then configure a shadow state property.
    modelBuilder.Entity<Company>(b=>{
        b.Property<int>("StatusId"); //this configures the shadow property
        b.Reference(c => c.Status).InverseCollection().ForeignKey("StatusId");
    });
