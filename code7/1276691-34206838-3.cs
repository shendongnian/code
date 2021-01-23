	using System;
	using System.Linq;
	namespace Utils
	{
		public static class TypeConverter
		{
			public static TDestination Convert<TSource, TDestination>(TSource source)
			{
				var destination = Activator.CreateInstance<TDestination>();
				var destProperties = destination.GetType()
                                                .GetProperties()
                                                .ToDictionary(x => x.Name);
				foreach (var prop in source.GetType().GetProperties())
				{
					if (destProperties.ContainsKey(prop.Name))
					{
						destProperties[prop.Name].SetValue(destination, prop.GetValue(source));
					}
				}
				return destination;
			}
		}
	}
