     ICollection<MediaItemGenre> pGenres = mediaItem.Genres;
    
     List<MediaItem> lItems = 
                     ltCOntext.MediaItems
                              .Where(m => m.Genres
                                           .Any(g => 
                                                mediaItem.Genres
                                               .Select(c=>c.Id).Contains(g.Id))).ToList();
