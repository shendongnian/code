    using (Windows.Web.Http.Filters.HttpBaseProtocolFilter filter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter())
    {
         using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient(filter))
         {
              using (Windows.Web.Http.HttpResponseMessage resp = await client.GetAsync(new Uri("Any Uri")))
              {
                   var content = resp.Content;
              }
          }
    }
