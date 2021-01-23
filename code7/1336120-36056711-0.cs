    byte[] bytes = (byte[])dr["FILEDATA"];    
    string name = (string)dr["FILENAME"] + (string)dr["FILEEXTENTION"];    
    var path = System.IO.Path.Combine(Application.StartupPath, name);
    System.IO.File.WriteAllBytes(path , bytes);
    this.axWindowsMediaPlayer1.URL = path;
    this.axWindowsMediaPlayer1.Ctlcontrols.play();
