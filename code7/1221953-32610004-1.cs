    var service = Authentcation.WMAuthenticateOauth(clientid, secret, "testmmm");
    
    
       IList<string> newlist = new List<string> ();
       newlist.Add("country");
       newlist.Add("device");
    
       SearchAnalyticsQueryRequest body = new SearchAnalyticsQueryRequest();
       body.StartDate = "2015-04-01";
       body.EndDate = "2015-05-01";
       body.Dimensions = newlist;
    
       var result = service.Searchanalytics.Query(body, "http://www.daimto.com/").Execute();
