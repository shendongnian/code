    var result = from p in context.Playlists
                 join pt in context.PlaylistTracks on p.PlaylistId equals pt.PlaylistId
                 join t in context.Tracks on pt.TrackId equals t.TrackId
                 where p.Name == "Brazilian Music"
                 select new { PlaylistName = p.Name, TrackId = t.TrackId, TrackName = t.Name };
    foreach (var p in result)
    {
      Console.WriteLine(p.PlaylistName + ", " + p.TrackId + ", " + p.TrackName);
    }
