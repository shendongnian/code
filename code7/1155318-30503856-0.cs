        private static void tracerlogs(string erreur, VLCControl.ControleUtilisateurVLC.LogLevels LvLog)
        {
            lock (LockLog) {
            string path = "logs.txt";//Sera redéfini dans l'appli
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(erreur + " " + LvLog.ToString());
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(erreur + " " + LvLog.ToString());
                    sw.Close();
                }
            }
            Console.WriteLine(erreur + " " + LvLog.ToString());
            }
        }
