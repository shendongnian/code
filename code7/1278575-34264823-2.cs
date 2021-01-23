	public async Task RunAsync()
	{
		var hotel = new Hotel();
		await Task.WhenAll(SetRooms(hotel), SetStars(hotel));
		Debug.Assert(hotel.NumberOfRooms.Equals(200));
		Debug.Assert(hotel.StarRating.Equals(5));
	}
