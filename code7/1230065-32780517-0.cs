	public class YamlSet<T> : HashSet<T>, IDictionary<T, object>
	{
		void IDictionary<T, object>.Add(T key, object value)
		{
			Add(key);
		}
		object IDictionary<T, object>.this[T key]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				Add(key);
			}
		}
		// ...
	}
