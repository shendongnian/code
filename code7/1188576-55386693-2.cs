	public static class DictionaryExtensions
	{
		public static Dictionary<TKey, TValue> ToDictionaryWithDupSelector<TKey, TValue>(
			this IEnumerable<TValue> enumerable,
			Func<TValue, TKey> groupBy, Func<IEnumerable<TValue>, TValue> selector = null) {
			if (selector == null)
				selector = new Func<IEnumerable<TValue>, TValue>(grp => grp.First());
			return enumerable
				.GroupBy(e => groupBy(e))
				.ToDictionary(grp => grp.Key, grp => selector(grp));
		}
	}
