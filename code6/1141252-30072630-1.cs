	public class DataObjectJavaScriptConverter : JavaScriptConverter
	{
		private static readonly Type[] _supportedTypes = new[]
		{
			typeof( Points )
		};
		public override IEnumerable<Type> SupportedTypes
		{
			get { return _supportedTypes; }
		}
		public override object Deserialize(IDictionary<string, object> dictionary,
											Type type,
											JavaScriptSerializer serializer)
		{
			if (type == typeof(Points))
			{
				var obj = new Points();
				if (dictionary.ContainsKey("X"))
					obj.X = serializer.ConvertToType<string>(dictionary["X"]);
				if (dictionary.ContainsKey("x"))
					obj.x = serializer.ConvertToType<string>(dictionary["x"]);
				return obj;
			}
			return null;
		}
		public override IDictionary<string, object> Serialize(
				object obj,
				JavaScriptSerializer serializer)
		{
			var dataObj = obj as Points;
			if (dataObj != null)
			{
				return new Dictionary<string, object>
				{
					{"X", dataObj.X },
					{"x", dataObj.x }
				};
			}
			return new Dictionary<string, object>();
		}
	}
