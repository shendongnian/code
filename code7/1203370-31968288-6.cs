    public async Task CrawlDataAsync(string dataLocation, bool repeat = false)
    {
      do
      {
        /*Most of processing done here, omitted for space...*/
        while(canCrawl == false)
        {
          await Task.Delay(250);
        }
      } while(repeat);
    }
