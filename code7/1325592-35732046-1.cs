    public class Folder
        {
            public static void CreateFolder()
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Gets desktop folder
                if(!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); 
                }
            }
        }
