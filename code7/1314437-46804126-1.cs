    public class FileManager
        {
            public string GetLocalFilePath(string filename)
            {
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return Path.Combine(path, filename);
            }
        }
