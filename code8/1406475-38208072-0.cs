    using QTOLibrary;
    foreach (string file in files)
    {
        axQTControl1.URL = file;
        // Create new movie object
        QTOLibrary.QTMovie mov = new QTOLibrary.QTMovie();
        mov = axQTControl1.Movie;
        string title = mov.Annotation[(int)QTAnnotationsEnum.qtAnnotationFullName];
        string artist = mov.Annotation[(int)QTAnnotationsEnum.qtAnnotationArtist];
        string album = mov.Annotation[(int)QTAnnotationsEnum.qtAnnotationAlbum];
        songs.Add(new Song(title, album, artist, file));
        WriteLine("Evaluated " + title);
    }
    // Make sure the previous file is not in use
    // This will prevent an IOException when the file is in use and cannot be moved
    axQTControl1.URL = "";
