	 private static async Task<List<PurchaseOrderListModel>> GetPendingPurchaseOrdersByUser(string token, UserModel userModel)
	{
		var service = ConfigurationManager.AppSettings["service:address"];
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri(service);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			
			var content = new StringContent(JsonConvert.SerializeObject(new
			{
				Filter = "PENDING",
				RequestType = "REQUEST"
			}), Encoding.UTF8, "application/json");
			var paramsValue = content.ReadAsStringAsync().Result;
			HttpResponseMessage response = await client.GetAsync($"purchaseorders/purchaseorders?parameters={paramsValue}");
			if (response.IsSuccessStatusCode)
			{
				var purchaseOrders = response.Content.ReadAsAsync<List<PurchaseOrderListModel>>().Result;
				//do work....
				//return some value
			}
		}
		return null;
	}
