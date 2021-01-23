    private JToken TraverseAndKeepNonNullNodes(JToken node)
	{
		if (node is JValue)
		{
			var val = ((JValue)node).Value;
			return val == null ? null : ((JValue)node).Parent;
		}
		else if (node is JProperty)
		{
			var property = (JProperty)node;
			return TraverseAndKeepNonNullNodes(property.Value);
		}
		else if (node is JObject)
		{
			List<JToken> nodesToKeep = new List<JToken>();
			foreach (var property in ((JObject)node).Properties())
			{
				var checkedNode = TraverseAndKeepNonNullNodes(property);
				if (checkedNode != null)
				{
					nodesToKeep.Add(checkedNode);
				}
			}
			((JObject)node).RemoveAll();
			nodesToKeep.ForEach(n => 
			{
				if (!n.HasValues)
				{
					return;
				}
				((JObject)node).Add((n is JObject || n is JArray) ? n.Parent : n);
			});
			return node;
		}
		else if (node is JArray)
		{
			List<JToken> nodesToKeep = new List<JToken>();
			foreach (var item in ((JArray)node))
			{
				var checkedNode = TraverseAndKeepNonNullNodes(item);
				if (checkedNode != null)
				{
					nodesToKeep.Add(checkedNode);
				}
			}
			((JArray)node).Clear();
			nodesToKeep.ForEach(n => {
				if (n.HasValues)
				{
					((JArray)node).Add(n);
				}
			});
			return node;
		}
		return null;
	}
