		public static T Parse<T>(String value)
		{
			object result = default(T);
			var typeT = typeof (T);
			if (typeT == typeof(Guid))
			{
				result = new Guid(value);
			}
			else if (typeT == typeof(TimeSpan))
			{
				result = TimeSpan.Parse(value);
			}
			else
			{
				result = Convert.ChangeType(value, typeT);
			}
			return (T)result;
		}
