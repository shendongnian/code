    //yelpJsonReturned is whatever you named your Json object returned by the API.
    //"businesses" indicates that you only want the parts of that object listed under businesses
    var businesses = yelpJsonReturned["businesses"]
    
    foreach (JsonValue business in businesses)
    {
         //parsing code goes here
    }
