    public sealed class TagRepository : IRepository
    {
        public IEnumerable<string> GetAllQueryAble()
        {
            return null; // Replace with real implementation.
        }
        public void Add(string name, DateTime dateAdded, DateTime lastModifiedDate, bool isDeleted)
        {
            this.Add(new Tag
            {
                Name             = item.ToString(),
                DateAdded        = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                IsDeleted        = false
            });     
        }
    }
