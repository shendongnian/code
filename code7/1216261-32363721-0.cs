	public class GeometryConverter : JavaScriptConverter
	{
	
		public override IEnumerable<Type> SupportedTypes
		{
			get { return new List<Type>(new Type[] {typeof(Geometry)}); }
		}
		
		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			Geometry geometry = obj as Geometry;
			
			if (geometry != null)
			{
				// Create the representation
				var result = new Dictionary<string, object>();
				
				if (geometry.coordinates.Count == 1)
				{
					result.Add("type", "Point");
					result.Add("coordinates", geometry.coordinates[0]);
				}
				else if (geometry.coordinates.Count > 1)
				{
					result.Add("type", "LineString");
					result.Add("coordinates", geometry.coordinates);
				}
				return result;
			}
			
			return new Dictionary<string, object>();
		}
	
		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			if (dictionary == null)
					throw new ArgumentNullException("dictionary");
			
			Geometry geometry = null;
			if (type == typeof(Geometry))
			{
				geometry = new Geometry();
				geometry.type = (string)dictionary["type"];
				geometry.coordinates = new List<List<double>>();
				if ( geometry.type == "Point")
				{
					ArrayList arrayList = (ArrayList)dictionary["coordinates"];
					geometry.coordinates.Add(ConvertCoordinates(arrayList));
				}
				else if (geometry.type == "LineString")
				{
					geometry.type = "LineString";
					ArrayList coordinatesList = (ArrayList)dictionary["coordinates"];
					foreach (ArrayList arrayList in coordinatesList)
					{
						geometry.coordinates.Add(ConvertCoordinates(arrayList));
					}
				}
			}
			return geometry;
		}
		
		private List<double> ConvertCoordinates(ArrayList coordinates)
		{
			var list = new List<double>();
			foreach (var coordinate in coordinates)
			{
				list.Add((double)System.Convert.ToDouble(coordinate));
			}
			return list;
		}
	}
