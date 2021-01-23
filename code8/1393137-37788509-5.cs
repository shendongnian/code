    public class Author
    {
        public Author()
        { }
        public int _AuthorID { get; set; }
        public string _AuthorName { get; set; }
        public List<Paper> _Papers { get; set; }
        public bool HasPapersForYear(int year)
        {
            return _Papers.Any(_paper => _paper._Year == year);
        }
        public bool HasPapersForYears(int startYear, int endYear)
        {
            return _Papers.Any(_paper => _paper._Year >= startYear && _paper._Year <= endYear);
        }
    }
