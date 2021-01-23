    var userAddresses =
		JObject
		.Parse(json)["Addresses"]
		.Select(x => new UserAddress()
			{
				Id = Int32.Parse(x["id"].ToString()),
				Properties =
					x
					.OfType<JProperty>()
					.Where(y => y.Name != "id")
					.ToDictionary(y => y.Name, y => y.Value.ToString())
			});
	
	var pairs =
		webServiceResponses
		.Join(
			userAddresses,
			response => response.Id,
			address => address.Id,
			(response, address) => new { Response = response, Address = address });
	
	foreach (var pair in pairs)
	{
		// Add each key\value pair in pair.Response to pair.Address.Properties.
	}
