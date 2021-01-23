    public class Book
    {
        private ReadOnlyCollection<Author> authors;
        public Book(ReadOnlyCollection<Author> authors)
        {
            //Is it okay to do this? 
            this.authors = authors;
        }
        public List<Author> Authors
        {
            get
            {   //Create a shallow copy
                return new ReadOnlyCollection<Author>(authors);
            }
        }
