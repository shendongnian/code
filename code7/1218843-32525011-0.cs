	using System;
	using System.Collections.Generic;
	using System.Linq;
	public static class IEnumerableExtensions
	{
		// Can be used to get all combinations at a certain level
		// Source: http://stackoverflow.com/questions/127704/algorithm-to-return-all-combinations-of-k-elements-from-n#1898744
		public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
		{
			return k == 0 ? new[] { new T[0] } :
				elements.SelectMany((e, i) =>
				elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
		}
		private static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource item)
		{
			if (source == null)
				throw new ArgumentNullException("source");
			yield return item;
			foreach (var element in source)
				yield return element;
		}
		// This one came from: http://stackoverflow.com/questions/774457/combination-generator-in-linq#12012418
		public static IEnumerable<IEnumerable<TSource>> Permutations<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException("source");
			var list = source.ToList();
			if (list.Count > 1)
				return from s in list
					   from p in Permutations(list.Take(list.IndexOf(s)).Concat(list.Skip(list.IndexOf(s) + 1)))
					   select p.Prepend(s);
			return new[] { list };
		}
	}
