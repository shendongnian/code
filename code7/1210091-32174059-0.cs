    public interface IDirectorySearcher : IDisposable {
       ISearchResultCollection FindAll();
    }
    class DirectorySearcherWrapper : IDirectorySearcher {
       DirectorySearcher mDirectorySearcher;
       DirectorySearcherWrapper(DirectorySearcher pDirectorySearcher) {
          mDirectorySearcher = pDirectorySearcher;
       }
       public static IDirectorySearcher Wrap(DirectorySearcher pDirectorySearcher) {
          return new DirectorySearcherWrapper(pDirectorySearcher);
       }
       public ISearchResultCollection FindAll() {
          return SearchResultCollectionWrapper.Wrap(mDirectorySearcher.FindAll());
       }
    }
