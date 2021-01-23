    albums.GroupBy(a => a.SingerID)
            .Select(g => new 
            {
                SingerID = g.Key,
                Albums = g.Select(a => new { a.AlbumName, a.AlbumDate })
            }) 
