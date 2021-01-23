    public interface IExcelWorksheetAdapter
    {
        //todo: implement this method, here you have everything you need for an image file
        void AddPicture(FileSystemItem aFile);
    }
    public class FileSystemItem
    {
        public virtual string FullPath { get; protected set; }
        public virtual int Level { get; set; }
        public virtual string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FullPath)) return string.Empty;
                return FullPath.Split('\\').Last();
            }
        }
        public virtual void Operation(IExcelWorksheetAdapter ws) { }
    }
    public class FolderItem : FileSystemItem
    {
        public FolderItem(string fullPath)
        {
            Items = new List<FileSystemItem>();
            if (!Directory.Exists(fullPath)) return;
            
            FullPath = fullPath;
            var files = Directory.GetFiles(FullPath).Select(p => new FileItem(p) { Level = this.Level + 1 }).ToList();
            Items.AddRange(files);
            var subFolders = Directory.GetDirectories(fullPath).Select(p => new FolderItem(p) {Level = this.Level + 1}).ToList();
            Items.AddRange(subFolders);
        }
        public List<FileSystemItem> Items { get; set; }
        public override void Operation(IExcelWorksheetAdapter ws)
        {
            Items.ForEach(x => x.Operation(ws));
        }
    }
    public class FileItem : FileSystemItem
    {
        public FileItem(string path)
        {
            if (File.Exists(path))
            {
                FullPath = path;
            }
        }
        public override void Operation(IExcelWorksheetAdapter ws)
        {
            ws.AddPicture(this);
        }
    }
    [TestFixture]
    public class DirectoryCompositeTest
    {
        [Test]
        public void Operation_for_a_directory_files()
        {
            var directory = new FolderItem(AppDomain.CurrentDomain.BaseDirectory);
            directory.Operation(new Sample()); // give your IExcelWorksheetAdapter implementation here.
        }
    }
    public class Sample : IExcelWorksheetAdapter
    {
        public void AddPicture(FileSystemItem aFile)
        {
            Console.WriteLine(Indent(aFile.Level) + aFile.Name);
        }
        private string Indent(int level)
        {
            string result = "";
            for (int i = 0; i < level; i++)
            {
                result += "-";
            }
            return result;
        }
    }
