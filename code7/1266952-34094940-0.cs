    public abstract class Base
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }
        
        public IList<Int32> PathIds
        {
            get
            {
                return !String.IsNullOrEmpty(Path) ? Path.Split(',').Select(x => Convert.ToInt32(x)).ToList() : null;
            }
        }
        public Int32 ParentId
        {
            get
            {
                if (PathIds.HasItemsAndNotNull() && PathIds.Count >= 2)
                    return PathIds[PathIds.Count - 2];
                return -1;
            }
        }
        public Int32 Level { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public String WriterName { get; set; }
        public String DocumentTypeAlias { get; set; }
    }
