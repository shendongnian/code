    var queryString = HttpUtility.ParseQueryString(curUri.Query);
    
                if (queryString.GetValues(null).Contains("ncr"))
                {
                    queryString.Add("ncr", "foo");
                    queryString.Remove("ncr");
                }
