        public class MyJsonObject
        {
            public string UniqueId { get; set; }
            public string Title { get; set; }
            public string Customer { get; set; }
            public string Description { get; set; }
            public List<JsonObjectItem> Items { get; set; }
        }
        public class JsonObjectItem
        {
            public string UniqueId { get; set; }
            public string Qty { get; set; }
            public string Location { get; set; }
        }
	public void ParseJson(string jsonText)
	{
		JObject jsonObject = JObject.Parse(jsonText);
		if(jsonObject != null)
		{
			JToken token = null;
			if(jsonObject.TryGetValue("Groups", out token))
			{
				foreach (var partData in token.Children())
				{
					if (!partData.HasValues)
						continue;
					MyJsonObject obj = partData.ToObject<MyJsonObject>();
					Part group = new Part(obj.UniqueId, obj.Title, obj.Customer, obj.Description);
					if(obj.Items.Count > 0)
					{
						foreach (var item in obj.Items)
						{
							short qty;
							if(!Int16.TryParse(item.Qty, out qty))
							{
								// Decide what to do if is error with parsing qty.
							}
							group.Items.Add(new Box(item.UniqueId, qty, item.Location, obj.UniqueId));
						}
					}
				}
			}
		}
	}
