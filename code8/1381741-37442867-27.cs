    public class CategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
			var result = new List<DynamicNode>();
		
            using (var db = new MyEntities())
            {
                // Create a node for each category
                foreach (var category in db.Categories)
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    // Key mapping
                    dynamicNode.Key = "Category_" + category.CategoryID;
                    // NOTE: parent category is defined as int?, so we need to check
                    // whether it has a value. Note that you could use 0 instead if you want.
                    dynamicNode.ParentKey = category.ParentCategoryID.HasValue ? "Category_" + category.ParentCategoryID.Value : "Home";
                    // Add route values
                    dynamicNode.Controller = "Category";
                    dynamicNode.Action = "Index";
                    dynamicNode.RouteValues.Add("id", category.CategoryID);
                    // Set title
                    dynamicNode.Title = category.Name;
                    result.Add(dynamicNode);
                }
            }
			
			return result;
        }
    }
    public class ProductDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
			var result = new List<DynamicNode>();
			
            using (var db = new MyEntities())
            {
                // Create a node for each product
                foreach (var product in db.Products)
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    // Key mapping
                    dynamicNode.Key = "Product_" + product.ProductID;
                    dynamicNode.ParentKey = "Category_" + product.CategoryID;
                    // Add route values
                    dynamicNode.Controller = "Product";
                    dynamicNode.Action = "Index";
                    dynamicNode.RouteValues.Add("id", product.ProductID);
                    // Set title
                    dynamicNode.Title = product.Name;
                    result.Add(dynamicNode);
                }
            }
			
			return result;
        }
    }
