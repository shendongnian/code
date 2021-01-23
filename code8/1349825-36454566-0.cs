    using (HttpContent content = response.Content)
	{
	    // ... Read the string.
	    string result = await content.ReadAsStringAsync();
	    // ... Display the result.
		Console.WriteLine(result);
	}
