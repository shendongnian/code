		var data = new []
		{ 
			new Record() { Id=1, Json = "{\"property\":\"data\"}" }, 
			new Record() { Id=2, Json = "{\"property\":\"data2\", \"property2\":[1, 2, 3]}" }
		};
		var serialized = JsonConvert.SerializeObject(data);
		Console.WriteLine(serialized);
