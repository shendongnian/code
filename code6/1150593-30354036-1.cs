    Newtonsoft.Json.Linq           // Namespace
    .JArray                        // Class
    .Parse(json)                   // Static method to parse string into a JArray
    .Select(x => new               // Select anonymous types
    {
	    UserId = x["UserID"],
	    Username = x["username"],
	    GroupId = x["GroupID"],
	    GroupName = x["GroupName"],
	    Money = x["Money"],
    })
    .GroupBy(x => x.UserId)        // Group by user id.
    .ContinueWithRemainingQuery();
