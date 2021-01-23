    public class BindableBase
    {
        public string InheritedName { get; set; }
    }
    
    public class Folder : BindableBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;  }
        }
        private List<Folder> subfolders=new List<Folder>();
        public List<Folder> Folders
        {
            get { return subfolders; }
            set{ subfolders= value; }
        }
    }
