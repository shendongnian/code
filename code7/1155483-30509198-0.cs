    public SongCollection GetAllByArtist(string artist)
    {
            SongCollection newSongs = new SongCollection();
            foreach (Song s in this) {
                if (s.Artist == artist)
                {
                    newSongs.Add(s);
                }
            }
            return newSongs;
    }
