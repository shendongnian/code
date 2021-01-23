	public class Comparator<T> : IEqualityComparer<T>
	{
		public bool Equals(T x, T y)
		{
			return JsonConvert.SerializeObject(x) == JsonConvert.SerializeObject(y);
		}
		public int GetHashCode(T obj)
		{
			return JsonConvert.SerializeObject(obj).GetHashCode();
		}
	}
