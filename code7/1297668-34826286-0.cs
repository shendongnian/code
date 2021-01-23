    public class Test
    {
        private List<Book> books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Genres = new List<Genre>()
                {
                    new Genre
                    {
                        Id = 1
                    },
                    new Genre
                    {
                        Id = 2
                    }
                }
            },
            new Book
            {
                Id = 2,
                Genres = new List<Genre>()
                {
                    new Genre
                    {
                        Id = 3
                    }
                }
            }
        };
        public IList<Book> Search(IList<int> genres)
        {
            return books.Where(x => x.Genres.Any(y => genres.Contains(y.Id))).ToList();
        }
    }
