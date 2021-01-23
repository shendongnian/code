    var songs = db.Songs.GroupBy(s => s.Genre, (genre, genreGroup) => new 
                                        { 
                                           Genre = genre, 
                                           ArtistGroup = genreGroup.GroupBy(s => s.Artist)
                                        });
