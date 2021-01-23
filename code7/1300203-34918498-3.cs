	public class Global
	{
		static Global _global = new Global();
		public static Global Dictionaries { get { return _global; } }
		public ResourceDictionary this[string index]
		{
			get { return App.Current.Resources[index] as ResourceDictionary; }
		}
	}
