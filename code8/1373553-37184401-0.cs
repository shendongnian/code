	public async Task GetDataFromTheWeb()
	//     ^^^^^ add this keyword
	{
		var baseAddress = new Uri("http://private-5e199-karhoofleetintegration.apiary-mock.com/");
		using (var httpClient = new HttpClient { BaseAddress = baseAddress })
		{
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept-charset", "utf-8");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Basic *sample_token*");
			using (var content = new StringContent("{  \"vehicles\": [    {      \"vehicle_type\": \""+ vehicale_type +"\",      \"vehicle_id\": \"" +vehicle_id+"\",  "\"heading\": 90      }    }  ]}", System.Text.Encoding.Default, "application/json"))
			{
				using (var response = await httpClient.PostAsync("{supplier_id}/availability?version=2", content))
				{
					string responseData = await response.Content.ReadAsStringAsync();
				}
			}
		}
	}
