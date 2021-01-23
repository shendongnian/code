    public List<ArtistAlbumVM> GetAlbumsByArtist(int id)
    {
      return db.Albums.Where(s=>s.ArtistId==id)
                      .Select(x=> new ArtistAlbumVm 
                             { 
                                 ArtistAge = x.Artist.Age,
                                 ArtistName =x.Artist.Name,
                                 ArtistLastName = x.Artist.LastName,
                                 AlbumDate = x.DateCreated,
                                 AlbumName = x.AlbumName
                              }).ToList();
    }
