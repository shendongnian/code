    public interface IBook
    {
        // List might be too specific, IEnumerable might work fine
        List<IPage> Pages { get; set; }
        // ctor loading is ok, but harder to unit test and define via interface
        void LoadPages(string fileName); 
    }
    public interface IPage
    {
        int Number { get; set; }
        string Text { get; set; }
    }
    public class DailyReflections : IBook
    {
        List<IPage> Pages { get; set; }
        
        public void LoadPages(string fileName)
        {            
            // Read one line at time, perhaps by appending line to StringBuilder
            // Attempt to parse date on this line, then when your date parses, 
            // create new DailyPage from StringBuilder text and date, then add to Pages.
            // Then clear your StringBuilder and continue until all lines are read.
            // e.g. https://msdn.microsoft.com/en-us/library/system.io.streamreader.readline(v=vs.110).aspx
        }
    }
    public class DailyPage : IPage
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
