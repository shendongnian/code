    public class AuthorCollection : IList<Author>
    {
        private IList<Author> backingAuthorList;
        public AuthorCollection(IList<Author> backingAuthorList)
        {
            if (backingAuthorList == null)
            {
                throw new ArgumentNullException("backingAuthorList");
            }
            this.backingAuthorList = backingAuthorList;
        }
        public void Add(Author item)
        {
            // Add your own logic here
            backingAuthorList.Add(item);
        }
    }
