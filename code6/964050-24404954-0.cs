    private static List<Donnees> CreerCollectionDonnees(string path) {
      var lesDonnees = new List<Donnees>();
    
      if ((File.GetAttributes(path) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint) {
        foreach (string fichier in Directory.GetDirectories(path)) {
          lesDonnees.Add(new Donnees { NomFichier = Path.GetFileName(fichier), Repertoire = Path.GetDirectoryName(fichier), Chemin = Path.GetPathRoot(fichier) });    
          lesDonnees.AddRange(CreerCollectionDonnees(fichier));
        }
      }
      return lesDonnees;
    }
