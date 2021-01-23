    var query = db.Albums.Include("Artists")
    .Join(db.Tracks.Include("Genre"), aa => aa.AlbumId, tr => tr.AlbumId,
    (aa, tr) => new
    {
        aa,
        tr
    }).Select(Finalrow => new TrackDTO
    {
        TrackId = Finalrow.tr.TrackId,
        TrackName = Finalrow.tr.Name,
        GenreId = Finalrow.tr.Genre.GenreId,
        GenreName = Finalrow.tr.Genre.Name,
        ArtistId = Finalrow.aa.ArtistId,
        ArtistName = Finalrow.aa.Artist.Name
    }).OrderBy(t => t.TrackId);
