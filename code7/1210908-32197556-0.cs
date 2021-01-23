	public class JsonOrderDepthFeedConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			//implement this if you want to convert to json in the same way
			throw new NotImplementedException();
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var order = JObject.Load(reader);
			var orderDepthFeed = new OrderDepthFeed
			{
				I = order["i"].Value<int>(),
				M = order["m"].Value<int>(),
				TickTimestamp = order["tick_timestamp"].Value<long>()
			};
			const int count = 5;
			orderDepthFeed.Ask = new double?[count];
			orderDepthFeed.AskVolume = new int?[count];
			orderDepthFeed.Bid = new double?[count];
			orderDepthFeed.BidVolume = new int?[count];
			for (var i = 1; i <= count; i++)
			{
				JToken aux;
				if (order.TryGetValue("ask" + i, out aux)) orderDepthFeed.Ask[i - 1] = aux.Value<double>();
				if (order.TryGetValue("ask_volume" + i, out aux)) orderDepthFeed.AskVolume[i - 1] = aux.Value<int>();
				if (order.TryGetValue("bid" + i, out aux)) orderDepthFeed.Bid[i - 1] = aux.Value<double>();
				if (order.TryGetValue("bid_volume" + i, out aux)) orderDepthFeed.BidVolume[i - 1] = aux.Value<int>();
			}
			return orderDepthFeed;
		}
		public override bool CanConvert(Type objectType)
		{
			return typeof(OrderDepthFeed) == objectType;
		}
	}
