     public SongCollection GetAllByArtist(string artist)
     {
        SongCollection newSongs = new SongCollection();
        newSongs.AddRange(this.Where(p=>p.Artist == artist))        
        return newSongs;
     }
