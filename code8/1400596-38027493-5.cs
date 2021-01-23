	public static partial class DirectoryUtils
	{
		public static IEnumerable<DirectoryInfo> EnumerateAccessibleDirectories(string path, bool all = false)
		{
			var filter = Func((IEnumerable<DirectoryInfo> source) => 
				source.Select(di =>
				{
					try { return new { Info = di, Children = di.EnumerateDirectories() }; }
					catch (UnauthorizedAccessException) { return null; }
				})
				.Where(e => e != null));
			var items = filter(Enumerable.Repeat(new DirectoryInfo(path), 1));
			if (all)
				items = items.Expand(e => filter(e.Children));
			else
				items = items.Concat(items.SelectMany(e => filter(e.Children)));
			return items.Select(e => e.Info);
		}
		static Func<T, TResult> Func<T, TResult>(Func<T, TResult> func) { return func; }
	}
