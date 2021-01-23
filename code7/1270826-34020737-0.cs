	public class Comparer : IEqualityComparer<List<KeyValuePair<string, string>>>
	{
		private static string KvpToString(KeyValuePair<string,string> kvp)
		{
			return (string.IsNullOrEmpty(kvp.Key) ? string.Empty : kvp.Key) + (string.IsNullOrEmpty(kvp.Value) ? string.Empty : kvp.Value);
		}
		public bool Equals(List<KeyValuePair<string, string>> x, List<KeyValuePair<string, string>> y)
		{
			var xx = x.Select(KvpToString).Aggregate((c, n) => c + n);
			var yy = y.Select(KvpToString).Aggregate((c, n) => c + n);
			return string.Compare(xx, yy) == 0;
		}
		public int GetHashCode(List<KeyValuePair<string, string>> obj)
		{
			return 0;
		}
	}
