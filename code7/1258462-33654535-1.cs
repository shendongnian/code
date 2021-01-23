    Table("Soldier");
    Id(x => x.ID).GeneratedBy.Identity();
    Map(x => x.FIRSTNAME);
    Map(x => x.LASTNAME);
    Reference(x => x.Commander).Column("COMMANDERID"); //Parent
    HasMany(x => x.Soldiers).Cascade.All().Inverse().KeyColumn("COMMANDERID"); //Children
