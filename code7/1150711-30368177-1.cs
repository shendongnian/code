        References(x => x.MainCnSubGroup)
            .Class<CnSubGroup>()
            .Access.Property()
            .Cascade.None()
            .LazyLoad()
            .Not.Insert()
            .Not.Update()
            .Columns("MAINCNOTE", "MAINCNSUB", "PARTFACTORY");
