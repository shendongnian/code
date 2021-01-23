    		var resultproductlist = await client.PostAsync(session.Values["URL"] + "/magemobpos/product/getProductID", contents);
			if (resultproductlist.IsSuccessStatusCode)
			{
				string trys = resultproductlist.Content.ReadAsStringAsync().Result;
				List<int> objProducts = JsonConvert.DeserializeObject<ProductlistResponse>(trys).productlistdata;
				LazyProductlistdata Product;
