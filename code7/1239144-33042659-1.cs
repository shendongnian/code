    private void RemoveNullNodes(JToken root)
	{
		if (root is JValue)
		{
			if (((JValue)root).Value == null)
			{
				((JValue)root).Parent.Remove();
			}
		}
		else if (root is JArray)
		{
			((JArray)root).ToList().ForEach(n => RemoveNullNodes(n));
			if (!(((JArray)root)).HasValues)
			{
				root.Parent.Remove();
			}
		}
		else if (root is JProperty)
		{
			RemoveNullNodes(((JProperty)root).Value);
		}
		else
		{
			var children = ((JObject)root).Properties().ToList();
			children.ForEach(n => RemoveNullNodes(n));
			if (!((JObject)root).HasValues)
			{
				if (((JObject)root).Parent is JArray)
				{
					((JArray)root.Parent).Where(x => !x.HasValues).ToList().ForEach(n => n.Remove());
				}
				else
				{
					var propertyParent = ((JObject)root).Parent;
					while (!(propertyParent is JProperty))
					{
						propertyParent = propertyParent.Parent;
					}
					propertyParent.Remove();
				}
			}
		}
	}
