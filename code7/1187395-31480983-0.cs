	public static class PedExtensions
	{
		private static readonly ConditionalWeakTable<Ped, PedProperties> _props = new ConditionalWeakTable<Ped, PedProperties>();
		
		public static bool GetMyBool(this Ped ped)
		{
			return _props.GetOrCreateValue(ped).MyBool;
		}
		
		public static void SetMyBool(this Ped ped, bool value)
		{
			_props.GetOrCreateValue(ped).MyBool = value;
		}
		
		private class PedProperties
		{
			public bool MyBool { get; set; }
		}
	}
	
