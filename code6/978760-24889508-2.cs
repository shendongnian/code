    public class JsonPlayerConverter : CustomCreationConverter<Player>
    {
    	public override Player Create(Type objectType)
    	{
    		throw new NotImplementedException();
    	}
    
    	public Player Create(Type objectType, JObject obj)
    	{
    		var array = obj["player"][0];
    		var content = array.Children<JObject>();
    
    		var player = new Player();
    		foreach (var prop in player.GetType().GetProperties())
    		{
    			var attr = prop.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();
    			var propName = ((JsonPropertyAttribute)attr).PropertyName;
    			var jsonElement = content.FirstOrDefault(c => c.Properties()
    									.Any(p => p.Name == propName));
    			var value = jsonElement.GetValue(propName);
    			var type = prop.PropertyType;
    
    			if (type == typeof(string))
    			{
    				prop.SetValue(player, (string)value, null);
    			}
    			else if (type  == typeof(PlayerName))
    			{
    				var playerName = JsonConvert.DeserializeObject<PlayerName>(value.ToString());
    				prop.SetValue(player, (PlayerName)playerName, null);
    			}
    			else if (type == typeof(Headshot))
    			{
    				var headshot = JsonConvert.DeserializeObject<Headshot>(value.ToString());
    				prop.SetValue(player, headshot, null);
    			}
    			else if (type == typeof(ByeWeeks))
    			{
    				var byeWeeks = JsonConvert.DeserializeObject<ByeWeeks>(value.ToString());
    				prop.SetValue(player, byeWeeks, null);
    			}
    			else if (type == typeof(List<EligiblePosition>))
    			{
    				var eligiblePositions = JsonConvert.DeserializeObject<List<EligiblePosition>>(value.ToString());
    				prop.SetValue(player, eligiblePositions, null);
    			}
    		}
    		return player;
    	}
    
    	public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
    	{
    		var obj = JObject.Load(reader);
    		var target = Create(objectType, obj);
    		serializer.Populate(obj.CreateReader(), target);
    
    		return target;
    	}
    }
