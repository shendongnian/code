    public class Folder
        {
            public static void CreateFolder()
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Gets desktop folder
                if(!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); 
                }
            }
        }
