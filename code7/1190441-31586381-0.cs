    public class Books
        {
            public Books()
            {
    
            }
    
            // apply this function each time befor doing serialization
            public void RunBeforeSerialization(Func<Book, bool> filter)
            {
                booksFilter = filter;
            }
    
            // this is the filter that you set before serialization
            Func<Book, bool> booksFilter = null;
    
            public string Customer { get; set; }
    
            List<Book> bookList = new List<Book>();
            public List<Book> BookList
            {
                get
                {
                    if (booksFilter == null) // the regular property usage
                    {
                        return bookList;
                    }
                    else // used when serialize
                    {
                        var temp = from book in bookList
                                  where booksFilter(book) // applying the filter
                                  select book;
                        
                        var res = temp.ToList();
                        booksFilter = null;
                        return res;
                    }
                }
                set
                {
                    bookList = value;
                }
            }
        }
