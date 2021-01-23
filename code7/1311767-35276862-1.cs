    foreach (var item in Model.PublishedSong.RelatedSongs != null 
                                 ? Model.PublishedSong.RelatedSongs.Select((value, i) => new { value, i }) 
                                 : Enumerable.Empty <dynamic>())
    {
    }
