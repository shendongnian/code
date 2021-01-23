        private static void Main(string[] args)
        {
            var files = GetFiles();
            var searchableFiles = files.Except(files.Where(f1 => f1.NeedsShowing ?? false && f1.ParentID == null)).ToList()
            var whereNeedShowing = (from f in files
                                    where f.NeedsShowing ?? false
                                    select new {Root = f, Descendants = FindDescendants(f.ID, searchableFiles) }).ToList();
            Debug.Assert(whereNeedShowing.Count == 2);
        }
        static List<FileHierarchy> FindDescendants(int? parentId, IEnumerable<FileHierarchy> files)
        {
            var children = files.Where(f => f.ParentID == parentId).ToList();
            foreach(var child in children.ToList())
            {
                var newChildren = FindDescendants(child.ID, files.Except(children));
                children.AddRange(newChildren);
            }
            return children;
        }
        static List<FileHierarchy> GetFiles()
        {
            var result = new List<FileHierarchy>();
            for (int i = 1; i <= 9; i++)
            {
                var file = new FileHierarchy()
                {
                    ID = i, 
                    ParentID = i == 1 || i == 5 || i == 8 ? (int?) null : i - 1, 
                    NeedsShowing = i == 1 || i == 8 ? true : (i == 5 ? false : (bool?) null)
                };
                result.Add(file);
                if (i == 3)
                {
                    file.ParentID = 1;
                }
                else if (i == 4)
                {
                    file.ParentID = 2;
                }
            }
            return result;
        }
    }
    public class FileHierarchy
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public bool? NeedsShowing { get; set; }
    }
