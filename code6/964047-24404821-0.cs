    internal class Program
     {
           private List<Donnees> lesDonnees = new List<Donnees>();
           public static void Main(string[] args)
            {
                Program program = new Program();
                var result  = program.CreerCollectionDonnees(@"C:\YOURPATH");
                // Loop through the collection received in 'result' variable
            }
            private List<Donnees> CreerCollectionDonnees(string path)
            {
                try
                {
                    if ((File.GetAttributes(path) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                    {
                        //string[] fichiers = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                        foreach (string fichier in Directory.GetDirectories(path))
                        {
                            lesDonnees.Add(new Donnees { NomFichier = Path.GetFileName(fichier), Repertoire = Path.GetDirectoryName(fichier), Chemin = Path.GetPathRoot(fichier) });
                            //Console.WriteLine("{0} {1}  ", new string(' ', indent), Path.GetFileName(fichier));
                            CreerCollectionDonnees(fichier);
                        }
                    }
                }
                catch (UnauthorizedAccessException) { }
                return lesDonnees;
            }
    }
