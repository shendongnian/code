	public class HydroElectric
	{
		private static bool _t1Bool = true;
		public static bool t1Bool 
		{
			get { return _t1Bool; }
			set
			{
				_t1Bool = value;
				prod = value ? 2f : 0f;
			}
		}
		public static float prod = 2f;
	}
