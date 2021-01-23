    public async Task CrawlDataAsync(string dataLocation, bool repeat = false)
    {
      for(;;)
      {
          /*Most of processing done here, omitted for space...*/
          while(canCrawl == false)
          {
            await Task.Delay(250);
          }
      }
    }
