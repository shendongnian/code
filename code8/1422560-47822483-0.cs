    public class FilesViewModel
    {
        public Guid? ParentObjectId { get; set; } // if you wish to associate these files with some parent record
        public IEnumerable<IFormFile> Files { get; set; }
    }
