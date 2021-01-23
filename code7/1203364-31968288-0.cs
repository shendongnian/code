    public void CrawlData(string dataLocation, bool repeat = false)
    {
      /*Most of processing done here, omitted for space...*/
      while(canCrawl == false)
      {
        Thread.Sleep(250); // yes, not ideal but a reasonable analogy.
      }
      CrawlData(dataLocation, repeat);
    }
