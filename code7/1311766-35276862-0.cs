    // This will return null if Relatedsongs is null, or call Select otherwise.
    foreach (var item in Model.PublishedSong.RelatedSongs?.Select((value, i) => new { value, i })  
                                 ?? Enumerable.Empty <dynamic>())
    {
    }
