     using (var dc = new DataClasses1DataContext())    {
                
        var matchedSong = (from c in dc.GetTable<Song>()
                           where c.SongID == SongID
                           select c).SingleOrDefault();
    
        if (matchedSong == null)
        {
            try
            {
                var song = dc.Song.Create();
                song.SongID = SongID;
                song.SongName = SongName;
                //...
                dc.Song.Add(song);
                dc.SubmitChanges();
                }
            } }
