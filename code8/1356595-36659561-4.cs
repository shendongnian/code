		/// <summary>Converts a Json.NET JArray into a List of T where T is a conventional .NET type (int, string, etc.)</summary>
		/// <param name="jArray">Json.NET JArray to convert</param>
		public IList<object> JArrayToList(JArray jArray) {
			return (List<object>)jArray.ToObject(typeof(IList));
		}
