    class DynatreeItem
    {
        public string title { get; set; }
        public bool isFolder { get; set; }
        public string key { get; set; }
        public List<DynatreeItem> children;
    
        public DynatreeItem(FileSystemInfo fsi)
        {
            title = fsi.Name;
            children = new List<DynatreeItem>();
    
            if (fsi.Attributes == FileAttributes.Directory)
            {
                isFolder = true;
                foreach (FileSystemInfo f in (fsi as DirectoryInfo).GetFileSystemInfos())
                {
                    children.Add(new DynatreeItem(f));
                }
            }
            else
            {
                isFolder = false;
            }
            key = title.Replace(" ", "").ToLower();
        }
    
        public string JsonToDynatree()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
