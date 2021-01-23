        References(x => x.MainCnSubGroup)
            .Class<CnSubGroup>()
            .Access.Property()
            .Cascade.None()
            .LazyLoad()
            .Columns("MAINCNOTE", "MAINCNSUB", "PARTFACTORY");
