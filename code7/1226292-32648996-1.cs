       public static void DirSearch(string sDir, string fileName, ref bool foundVar)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, fileName))
                    {
                        if (Path.GetFileName(f) == fileName)
                        {
                            Console.WriteLine("directory is  and inside it is " + f);
                            OpenExeFile(f);
                            foundVar = true;
                            break;
                        }
                    }
                    DirSearch(d, fileName, ref foundVar);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
