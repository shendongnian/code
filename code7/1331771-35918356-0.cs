    public IHttpActionResult GetArtist(string name) {       
        IEnumerable<Artist> ArtistQuery = from Artist in artists
                                          where Artist.Name.Contains(name)
                                          select Artist;
        if (ArtistQuery.Count() == 0) {
            return NotFound();
        }
        return Ok(ArtistQuery.First());
    }
