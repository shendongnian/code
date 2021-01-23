    public TagMap()
    {
        Id(x => x.Id)
            .Column("Kint_T01_IdTag")
            .GeneratedBy.Assigned();
        Reference(x => x.ParentTag).Access.CamelCaseField();
        HasMany(x => x.ChildTag)
                .Inverse()
                .KeyColumn("ParentId")
                .Cascade.AllDeleteOrphan()
                .Access.CamelCaseField().ReadOnly();
    }
