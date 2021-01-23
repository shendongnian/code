    public async void GetRequest(){                string url = "APIurl";
                    HttpClient _client = new HttpClient();
                    HttpResponseMessage _response = await _client.GetAsync(new Uri(url));
                    if (_response.IsSuccessStatusCode)
                    {
                        string APIResponse = await _response.Content.ReadAsStringAsync();
                        var myObject = Newtonsoft.Json.Linq.JArray.Parse(APIResponse).ToObject<MyClass>();
                    }
    }
