    private static readonly TaskScheduler _staScheduler = new StaTaskScheduler( 1 );
    
    [Route( "merge" )]
    [HttpGet]
    public async Task<HttpResponseMessage> MergeXps() {
      var paginator = await Task<DocumentPaginator>.Factory.StartNew(
        () =>
          {
            var xpsFiles = Directory.GetFiles( "C:\\Xps", "*.xps" );
            var documentPaginator = CreateMergedDocument( xpsFiles );
    
            return documentPaginator;
          },
        CancellationToken.None,
        TaskCreationOptions.None,
        _staScheduler );
    
      var response = new HttpResponseMessage();
      response.Content = new StringContent( $"Merged Document Page Count: {paginator.PageCount}" );
      response.StatusCode = HttpStatusCode.OK;
      return response;
    }
