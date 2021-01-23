	var c = new RestClient(baseurl);
	var r = new RestRequest(url, Method.POST);  // <-- must specify a Method that has a body
	// shorthand
	r.AddJsonBody(dictionary);
	// longhand
	r.RequestFormat = DataFormat.Json;
	r.AddBody(d);
	var response = c.Execute(r); // <-- confirmed*
