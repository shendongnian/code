    public sealed class TagRepository : IRepository
    {
        public string GetAllQueryAble()
        {
            return ""; // Replace with real implementation.
        }
        public void Add(string name, DateTime dateAdded, DateTime lastModifiedDate, bool isDeleted)
        {
            this.Add(new Tag(name, dateAdded, lastModifiedDate, isDeleted));
        }
    }
