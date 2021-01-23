	namespace NESTshop.Infrastructure
	{
		public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
		{
			public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
			{
				using (var db = new ApplicationDbContext())
				{
					foreach (Product p in db.Product)
					{
						DynamicNode n = new DynamicNode();
						n.Title = p.ProductTitle;
						n.Key = "Product_" + p.ProductID;
						
						// IMPORTANT: Setup the relationship with the 
						// parent node (category) by using the foreign key in 
                        // your database. ParentKey must exactly match the Key
                        // of the node this node is to be a child of.
						// If this is a many-to-many relationship, you will need
						// to join to the table that resolves the relationship above
						// and use the right key here.
						n.ParentKey = "Kategoria_" + p.CategoryID;
						
						// Add your route values
						// Route Option 1
						n.RouteValues("id", p.ProductID);
						
						// Route Option 2
						// n.RouteValues("ProductID", p.ProductID);
						// Optional: Add any route values to match regardless of value
						// n.PreservedRouteParameters.Add("myKey");
						yield return n;
					}
				}
			}
		}
	}
