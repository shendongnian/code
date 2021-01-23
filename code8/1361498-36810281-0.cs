            GeographicRegion userRegion = new GeographicRegion();
            string regionCode = userRegion.CodeTwoLetter;
            
            DateTimeFormatter timeFormatter = new DateTimeFormatter("hour minute", new[] { regionCode });
            string correctTime = timeFormatter.Format(DateTime.Now);           
            DateTimeFormatter dateFormatter = new DateTimeFormatter("dayofweek month day", new[] { regionCode });
            string correctDate = dateFormatter.Format(DateTime.Now);
