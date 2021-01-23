	var NewResponse = await client.PostAsync("https://www.chromeriver.com/receipts/doit", NewContent);
	System.Net.Http.HttpContent content = NewResponse.Content; // actually a System.Net.Http.StreamContent instance but you do not need to cast as the actual type does not matter in this case
	using(var file = System.IO.File.Create("somePathHere.pdf")){ // create a new file to write to
		var contentStream = await content.ReadAsStreamAsync(); // get the actual content stream
		await contentStream.CopyToAsync(file); // copy that stream to the file stream
		await file.FlushAsync(); // flush back to disk before disposing
	}
