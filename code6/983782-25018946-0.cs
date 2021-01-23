    Task CheckWebPageAsync(string url) {
      if(url == null) // argument check            
        throw Exception("Bad url");                     
      return CheckWebPageInternalAsync(url);
    }
    private async Task CheckWebPageInternalAsync(string url) {
      if((await PageDownloader.GetPageContentAsync(url)).Contains("error")) 
        throw Exception("Error on the page");
    }
