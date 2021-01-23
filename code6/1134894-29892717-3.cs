	List<dynamic> list = new List<dynamic>();
	foreach (var entry in result)
	{
		dynamic itemToAdd = new ExpandoObject();
		var expandoX = Extensions.ToDynamic(entry.x);
		var dictX = expandoX as IDictionary<string, object>;
		if(dictX != null)
		{
			foreach (KeyValuePair<string, object> e in dictX)
			{
				var dictO = itemToAdd as IDictionary<string, object>;
				if(!dictO.ContainsKey(e.Key))
					dictO.Add(e.Key, e.Value);
			}
		}
		if (entry.y != null)
		{
			var expandoY = Extensions.ToDynamic(entry.y);
			var dictY = expandoY as IDictionary<string, object>;
			if(dictY != null)
			{
				foreach (KeyValuePair<string, object> e in dictY)
				{
					var dictO = itemToAdd as IDictionary<string, object>;
					if(!dictO.ContainsKey(e.Key))
						dictO.Add(e.Key, e.Value);
				}
			}
		}
		list.Add(itemToAdd);
	}
