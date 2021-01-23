        if(!string.IsNullOrEmpty(lines[0]) && lines[0].Length >= 5)
        {
           double dd ;
    	   Double.TryParse(lines[0].Substring(4), out dd)
           Poi.Latitude = dd; 
        }
        if(!string.IsNullOrEmpty(lines[1]) && lines[1].Length >= 5) 
        {
           double dd ;
    	   Double.TryParse(lines[1].Substring(4), out dd)
           Poi.Longitude = dd; 
         }
