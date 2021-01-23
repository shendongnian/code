    public interface IReporter
    {
        void  Write(int site, DateTime start, DateTime end);
        void  Write(int site, SiteLocalDateTime start, SiteLocalDateTime end);
    }
