    public void CrawlData(string dataLocation, bool repeat = false)
    {
      do
      {
        /*Most of processing done here, omitted for space...*/
        while(canCrawl == false)
        {
          Thread.Sleep(250);
        }
      } while(repeat);
    }
