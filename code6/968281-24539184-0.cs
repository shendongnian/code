	[Serializable]
	[AttributeUsage(AttributeTargets.Property)]
	public class CopyPropertyAttribute : Attribute
	{
		public static void CopyProperties(object src, object dest)
		{
			// todo: cache
			var props = src.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(CopyPropertyAttribute), true).Length > 0).ToList();
			props.ForEach(p => p.SetValue(dest, p.GetValue(src, null), null));
		}
	} 
