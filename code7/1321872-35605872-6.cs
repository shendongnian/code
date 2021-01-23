    public static class Books : IBookFinder
    {
        private Books(Books next, string book, Books previous)
        {
            Next = next;
            Book = book;
            Previous = previous;
        }
    
        public Books Next { get; }
        public Books Previous { get; }
        public string Book { get; }
    
        public static Books Previous(this Books previous, string book)
        {
            return new Books(this, book, previous);
        }
    
        public static Books Create(string book)
        {
            return new Books(null, book, null);
        }
    
        private Books FromLeft(Books book, int x){
            if(x-- > 0) return FromLeft(book?.Next, x); // Check for null if you're not using C#6
            return book;
        }
    
        private Books FromRight(Books book, int x){
            if(x-- > 0) return FromRight(book?.Previous, x); // Check for null if you're not using C#6
            return book;
        }
    }
