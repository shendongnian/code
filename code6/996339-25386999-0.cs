     public DataFeedExample()
        {
    
          // Configure GA API.
          AnalyticsService asv = new AnalyticsService("gaExportAPI_acctSample_v2.0");
    
          // Client Login Authorization.
          asv.setUserCredentials(CLIENT_USERNAME, CLIENT_PASS);
    
          // GA Data Feed query uri.
          String baseUrl = "https://www.google.com/analytics/feeds/data";
    
          DataQuery query = new DataQuery(baseUrl);
          query.Ids = TABLE_ID;
          query.Dimensions = "ga:source,ga:medium";
          query.Metrics = "ga:visits,ga:bounces";
          query.Segment = "gaid::-11";
          query.Filters = "ga:medium==referral";
          query.Sort = "-ga:visits";
          query.NumberToRetrieve = 5;
          query.GAStartDate = "2010-03-01";
          query.GAEndDate = "2010-03-15";
          Uri url = query.Uri;
          Console.WriteLine("URL: " + url.ToString());
    
    
          // Send our request to the Analytics API and wait for the results to
          // come back.
    
          feed = asv.Query(query);
    
    
        }
