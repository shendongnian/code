    var objservice = new Restaurant.GoogleWebService();
    var originPostCode = (String)Session["Data"];
    var results = Model.Select(item => 
    	new RestaurantResult {
    		Location = item.Location,
    		PostCode = item.PostCode,
    		Distance = objservice.GetDrivingDistanceInMiles(originPostCode,
                item.Postcode.ToString()).ToString()
    	}).OrderBy(item => item.Distance);
    //Pass results to the View here.
