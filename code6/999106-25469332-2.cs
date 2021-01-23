    var root = XElement.Load(path);
    root = root.Element("dict");
    var tracks = root.Elements("key").First(c => (string)c == "Tracks").NextNode.Elements("dict");
    IEnumerable<Track> parsedTracks =  tracks.Select(c => new Track()
                                                          {
                                                              Name = GetValue<string>(c, "Name"),
                                                              Explicit = GetValue<bool>(c, "Explicit")
                                                          });
