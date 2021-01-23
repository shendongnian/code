    public interface IDirectorySearcher : IDisposable {
       IEnumerable<ActiveDirectoryUser> FindAll();
    }
    class DirectorySearcherWrapper : IDirectorySearcher {
       DirectorySearcher mDirectorySearcher;
       DirectorySearcherWrapper(DirectorySearcher pDirectorySearcher) {
          mDirectorySearcher = pDirectorySearcher;
       }
       public static IDirectorySearcher Wrap(DirectorySearcher pDirectorySearcher) {
          return new DirectorySearcherWrapper(pDirectorySearcher);
       }
       public IEnumerable<ActiveDirectoryUser> FindAll() {
          return
             mDirectorySearcher
             .FindAll()
             .Cast<SearchResult>()
             .Select(result => result.GetDirectoryEntry())
             .Select(/*BuildNewADUser*/)
             .ToList();
       }
    }
