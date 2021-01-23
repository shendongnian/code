        //DO NOT declare lesDonnees!
        try
        {
            if ((File.GetAttributes(path) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
            {
                //string[] fichiers = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (string fichier in Directory.GetDirectories(path))
                {
                    lesDonnees.Add(new Donnees { NomFichier = Path.GetFileName(fichier), Repertoire = Path.GetDirectoryName(fichier), Chemin = Path.GetPathRoot(fichier) });
                    //Console.WriteLine("{0} {1}  ", new string(' ', indent), Path.GetFileName(fichier));
                    lesDonnees.AddRange(CreerCollectionDonnees(fichier));
                    CreerCollectionDonnees(fichier);
                }
            }
        }
        catch (UnauthorizedAccessException) { }
        return lesDonnees;
