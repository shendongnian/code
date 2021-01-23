    public void CrawlData(string dataLocation, bool repeat = false)
    {
      start:
      /*Most of processing done here, omitted for space...*/
      while(canCrawl == false)
      {
        Thread.Sleep(250);
      }
      goto start;
    }
