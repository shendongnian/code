    public static object GetSongList(bool lib = true, bool albumArt = true)
    {
         MediaLibrary mediaLib = new MediaLibrary();
         var songs = mediaLib.Songs;
    
         if (lib)
         {
              return songs;
         }
         else
         {
              var list = new List<MusicTitle>();
              foreach (var song in songs)
              {
                   list.Add(new MusicTitle()
                   {
                       Artist = song.Artist.Name,
                       Title = song.Name,
                       Duration = (new DateTime(song.Duration.Ticks)).ToString("mm:ss"),
                       Album = song.Album.Name, 
                       Art = albumArt ? GetAlbumArt(song, 100) : null
                   });
              }
    
              return list;
          }
    }
