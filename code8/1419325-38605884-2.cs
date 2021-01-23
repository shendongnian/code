    string LogPath = null;
    using (StreamReader file = new System.IO.StreamReader(ConfigPath)) {
      while((line = file.ReadLine()) != null) {
        if (line.StartsWith("comdir="))
          LogPath = line.Substring(7);
      }
    }
