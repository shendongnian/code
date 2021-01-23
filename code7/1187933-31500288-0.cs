    internal class Book
    {
        public Book(string title, string author, string publisher, string date)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Date = date;
        }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Publisher { get; private set; }
        public string Date { get; private set; }
        public override string ToString()
        {
            return string.Format("{0}, {1}. {2}. {3}.", Author, Date, Title, Publisher);
        }
    }
