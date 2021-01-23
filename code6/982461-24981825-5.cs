    // correct
    public ArtistMap()
    {
        ..
        HasMany(x => x.AlbumList)
           .Table("Album")
           .KeyColumn("ArtistId")         // this is the relation
           .Cascade.All().Not.LazyLoad();
    }
