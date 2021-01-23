	public static class LayoutControllerExtensions
	{
		public static IEnumerable<Element> GetChildren(this ILayoutController source)
		{
			return source.Children;
		}
	}
