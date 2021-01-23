    public  static class AuthorService
    {
        ...
    
        public static void RemoveById(int id)
        {
            using (var scope = new UnitOfWork(Container))
            {
                var author = Container.Authors.SingleOrDefault(x => x.Id == id);
                Container.Authors.Remove(author);
            }
        }
        ...
