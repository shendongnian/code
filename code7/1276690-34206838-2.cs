	using System;
	using System.Collections.Generic;
	using System.Reflection;
	namespace Utils
	{
		public static class TypeConverter
		{
			static void ForEachProperty(Type type, Action<PropertyInfo> action)
			{
				var properties = type.GetProperties();
				foreach (var prop in properties)
				{
					action(prop);
				}
			}
			public static TDestination Convert<TSource, TDestination>(TSource source)
			{
				var destination = Activator.CreateInstance<TDestination>();
				var destinationProperties = new Dictionary<string, PropertyInfo>();
				ForEachProperty(destination.GetType(), x => destinationProperties[x.Name] = x);
				ForEachProperty(source.GetType(),
					x =>
					{
						if (destinationProperties.ContainsKey(x.Name))
						{
							destinationProperties[x.Name].SetValue(destination, x.GetValue(source));
						}
					});
				return destination;
			}
		}
	}
