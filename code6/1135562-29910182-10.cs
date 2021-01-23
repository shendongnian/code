    var album = new Album(new List<Track> {
      new Track { Name = "Blonde"}, 
      new Track { Name = "K.-O."}, 
      new Track { Name="Alcaline"}, 
      new Track { Name="Seulement pour te plaire"}, 
      new Track { Name="L'amour renfort"},
      new Track { Name="Bi"},
      new Track { Name="Mon planeur"},
      new Track { Name="Ce qui tue l'amour"},
      new Track { Name="Tweet"},
      new Track { Name="Charles est stone"},
      new Track { Name="Mylène Farmer"},
      new Track { Name="Plus de bye bye"}
    });
    var culture = new CultureInfo("fr-FR");
    var tracks = album.Tracklist.OrderBy(t => t.Name, StringComparer.Create(culture, false));
    tracks.ToList().ForEach(Console.WriteLine);
