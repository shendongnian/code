	public static class CloneHelper 
	{
		public static T Clone<T>(T source)
		{
		    var serialized = JsonConvert.SerializeObject(source);
		    return JsonConvert.DeserializeObject<T>(serialized);
		}
	}
    var copyProduct = CloneHelper.Clone<Product>(product);
