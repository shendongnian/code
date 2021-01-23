	var subscription =
		lV_Items.ToObservable()
			.SelectMany(x =>
				Observable
					.Interval(TimeSpan.FromSeconds(x.Interval))
					.SelectMany(n =>
						Observable
							.Using(
								() => new System.Net.Http.HttpClient(),
								client => Observable.FromAsync(
									() => client.GetStringAsync("http://localhost/item.php?itemname=" + x.MarketName)))
							.Select(x => JObject.Parse(x))
							.Select(o => new { lv_item = x, price = (string)o["price"], amount = (string)o["amount"] })))
			.ObserveOn(lV_Items)
			.Subscribe(result =>
			{
				result.lv_item.Amount = result.amount;
				result.lv_item.Price = result.price;
			});
