    var query3 = db.Albums.Include("Artists").Join(db.Tracks.Include("Genre"), aa => aa.TrackId, tr => tr.ID, (aa, tr) => new
                {
                    aa,
                    tr
                }).Select(Finalrow => new TrackDTO
                {
                    TrackId = Finalrow.tr.ID,
                    TrackName = Finalrow.tr.Name,
                    GenreId = Finalrow.tr.GENREs.Select(g => g.ID).FirstOrDefault(),
                    GenreName = Finalrow.tr.GENREs.Select(g => g.Name).FirstOrDefault(),
                    ArtistId = Finalrow.aa.Artists.Select(a => a.Id).FirstOrDefault(),
                    ArtistName = Finalrow.aa.Artists.Select(a => a.Name).FirstOrDefault()
                }).OrderBy(t => t.TrackId);
