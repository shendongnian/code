	public interface ICachedRouteDataProvider<TPrimaryKey>
	{
		IDictionary<string, TPrimaryKey> GetPageToIdMap();
	}
	public class CmsCachedRouteDataProvider : ICachedRouteDataProvider<int>
	{
		public IDictionary<string, int> GetPageToIdMap()
		{
			// Lookup the pages in DB
			return (from page in DbContext.Pages
					select new KeyValuePair<string, int>(
						page.Url.TrimStart('/').TrimEnd('/'),
						page.Id)
					).ToDictionary(pair => pair.Key, pair => pair.Value);
		}
	}
