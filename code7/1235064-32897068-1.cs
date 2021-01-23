    public interface ISearchResponse
    {
        void Foo();
    }
    public class AnimeSearchResponse : ISearchResponse
    {
        public void Foo() {}
    }
    public abstract class Searcher
    {
        abstract ISearchResponse Search();
        abstract ISearchResponse SearchAsync();
    }
    
    public class AnimeSearcher : Searcher
    {
        public override ISearchResponse Search(string searchTerm)
        {
            return new AnimeSearchResponse(searchTerm);
        }
        public override ISearchResponse SearchAsync(string searchTerm)
        {
            return new AnimeSearchResponse(searchTerm);
        }
    }
