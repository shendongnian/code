    var client = new HttpClient();
    var request = new HttpRequestMessage() {
                                            RequestUri = new Uri("http://www.someURI.com"),
                                            Method = HttpMethod.Get,
                                            ...........
                                        };
    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain")); }
