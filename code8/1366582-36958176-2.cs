	public static class JSONObjectExtensions
	{
		public static IEnumerable<KeyValuePair<string, JSONObject>> NameValuePairs(this JSONObject obj)
		{
			if (obj == null)
				throw new ArgumentNullException();
			if (obj.type != JSONObject.Type.OBJECT)
				throw new InvalidOperationException(string.Format("Incoming object type {0} is not JSONObject.Type.OBJECT.", obj.type));
			for (int i = 0; i < obj.list.Count; i++)
			{
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				yield return new KeyValuePair<string, JSONObject>(key, j);
			}
		}
	}
