	public class BaseMapper<T> : ClassMapper<T> where T : BaseClass
	{
		public BaseMapper()
		{
		}
		protected override void AutoMap()
		{
			CustomAutoMap(null);
		}
		private void CustomAutoMap(Func<Type, PropertyInfo, bool> canMap)
		{
			Type type = typeof(T);
			bool hasDefinedKey = Properties.Any(p => p.KeyType != KeyType.NotAKey);
			PropertyMap keyMap = null;
			foreach (var propertyInfo in type.GetProperties())
			{
				// Exclude virtual properties
				if (propertyInfo.GetGetMethod().IsVirtual)
				{
					continue;
				}
				if (Properties.Any(p => p.Name.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase)))
				{
					continue;
				}
				if ((canMap != null && !canMap(type, propertyInfo)))
				{
					continue;
				}
				PropertyMap map = Map(propertyInfo);
				if (!hasDefinedKey)
				{
					if (string.Equals(map.PropertyInfo.Name, "id", StringComparison.InvariantCultureIgnoreCase))
					{
						keyMap = map;
					}
					if (keyMap == null && map.PropertyInfo.Name.EndsWith("id", true, CultureInfo.InvariantCulture))
					{
						keyMap = map;
					}
				}
			}
			if (keyMap != null)
			{
				keyMap.Key(PropertyTypeKeyTypeMapping.ContainsKey(keyMap.PropertyInfo.PropertyType)
					? PropertyTypeKeyTypeMapping[keyMap.PropertyInfo.PropertyType]
					: KeyType.Assigned);
			}
		}
	}
}
