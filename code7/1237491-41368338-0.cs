    var musicDir = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
    var paths = Directory.EnumerateFiles(musicDir, @"*.mp3");
    var doc = new XDocument(
        new XElement("root", // place the Music elements under root
            from x in paths.Select((p, i) => new { Path = p, Index = i })
            let file = TagLib.File.Create(x.Path)
            select new XElement("Music",
                new XAttribute("id", x.Index + 1),
                new XElement("Album", file.Tag.Album),
                new XElement("AlbumArtist", file.Tag.FirstAlbumArtist),
                new XElement("Title", file.Tag.Title),
                new XElement("Track", file.Tag.Track),
                new XElement("Genre", file.Tag.FirstGenre),
                new XElement("Path", x.Path)
            )
        )
    );
    doc.Save(Path.Combine(musicDir, "Data.Xml"));
