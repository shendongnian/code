    public class ViewModel
    {
        public ObservableCollection<string> ImagePaths { get; private set; }
            = new ObservableCollection<string>();
        public void LoadImagePaths(string path)
        {
            var dir = new DirectoryInfo(path);
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                ImagePaths.Add(file.FullName);
            }
        }
    }
