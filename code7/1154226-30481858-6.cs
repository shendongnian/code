    class Analyzer
    {
     private List<IDataFetcher> _fetcherList;
    
     public Analyzer(IDataFetcher[] fetcherList)
     {
      _fetcherList = new List<IDataFetcher>(fetcherList);
     }
    
     public void PerformAnalysis()
     {
      foreach (IDataFetcher dtFetcher in _fetcherList)
      {
       Console.WriteLine(dtFetcher.getData());
      }
     }
    }
