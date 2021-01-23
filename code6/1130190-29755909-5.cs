	public class PagesDynamicNodeProvider
	  : DynamicNodeProviderBase
	{
		private const string IsraelOnlyItemsPageKey = "publications-in-hebrew";
		
		public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode siteMapNode)
		{
			using (var context = new Context())
			{ 
				var pages = context.Pages
							.Include(p => p.Language)
							.Where(p => p.IsPublished)
							.OrderBy(p => p.SortOrder)
							.ThenByDescending(p => p.PublishDate)
							.ToArray();
				foreach (var page in pages)
				{
					var node = new DynamicNode(
					  key: page.MenuKey,
					  parentKey: page.MenuParentKey,
					  title: page.MenuTitle,
					  description: page.Title,
					  controller: "Home",
					  action: "Page");          
					// Add the visibility provider to each node that has the condition you want to check
					if (page.MenuKey == IsraelOnlyItemsPageKey)
					{
						node.VisibilityProvider = typeof(IsraelVisibilityProvider).AssemblyQualifiedName;
					}
					node.RouteValues.Add("id", page.PageId);
					node.RouteValues.Add("pagetitle", page.MenuKey);
					yield return node;
				}
			}
		}
	}
