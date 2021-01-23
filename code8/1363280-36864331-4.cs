    		var resultproductlist = await client.PostAsync(session.Values["URL"] + "/magemobpos/product/getProductList", contents);
			if (resultproductlist.IsSuccessStatusCode)
			{
				string trys = resultproductlist.Content.ReadAsStringAsync().Result;
				List<Productlistdata> objProducts = JsonConvert.DeserializeObject<ProductlistResponse>(trys).productlistdata;
				Productlistdata Product;
