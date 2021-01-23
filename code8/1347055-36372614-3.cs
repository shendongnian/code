	namespace NESTshop.Infrastructure
	{
		public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
		{
			public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
			{
				using (var db = new ApplicationDbContext())
				{
					foreach (Category c in db.Category)
					{
						DynamicNode n = new DynamicNode();
						n.Title = c.CategoryTitle;
						n.Key = "Kategoria_" + c.CategoryID;
						
						// Optional: Add the parent key 
						// (and put a key="Home" on the node that you want these nodes children of)
						//n.ParentKey = "Home";
						
						// Add your route values
						// Route Option 1
						n.RouteValues("id", c.CategoryID);
						
						// Route Option 2
						// n.RouteValues("CategoryID", c.CategoryID);
						// Optional: Add any route values to match regardless of value
						// n.PreservedRouteParameters.Add("myKey");
						yield return n;
					}
				}
			}
		}
	}
