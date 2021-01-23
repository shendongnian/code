    public void GetAllFiles(string sdir, List<string> files) {
      foreach (string dir in Directory.GetDirectories(sdir)) {
        try {
          foreach (string file in Directory.GetFiles(dir, "*.*")) {
            string filename = Path.GetFileName(file);
            files.Add(filename);
          }
          GetAllFiles(dir, files);
        } catch (Exception error) {
          Console.WriteLine(error.Message);
        }
      }
    }
