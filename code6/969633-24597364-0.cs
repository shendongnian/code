    HasMany(x => x.Dedos)
      //.Inverse().Cascade.All().KeyColumn("DedoID").Inverse();
      .Inverse().Cascade.All().KeyColumn("TomaID").Inverse();
    HasMany(x => x.Firmas)
      //.Inverse().Cascade.All().KeyColumn("FirmaID").Inverse();
      .Inverse().Cascade.All().KeyColumn("TomaID").Inverse();
    HasMany(x => x.Fotos)
      //.Inverse().Cascade.All().KeyColumn("FotoID").Inverse();
      .Inverse().Cascade.All().KeyColumn("TomaID").Inverse();
