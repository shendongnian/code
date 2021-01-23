    public class ProductRouteHandler : IRouteHandler 
    { 
       public IHttpHandler GetHttpHandler(RequestContext requestContext) 
       { 
          string productName = requestContext.RouteData.Values["ProductName"] as string; 
    
          if (string.IsNullOrEmpty(productName)) 
             return Helpers.GetNotFoundHttpHandler(); 
          else 
          { 
             // Get information about this product 
             NorthwindDataContext DataContext = new NorthwindDataContext(); 
             Product product = DataContext.Products.Where(p => p.ProductName == productName).SingleOrDefault(); 
    
             if (product == null) 
                return Helpers.GetNotFoundHttpHandler(); 
             else 
             { 
                // Store the Product object in the Items collection 
                HttpContext.Current.Items["Product"] = product; 
    
                return BuildManager.CreateInstanceFromVirtualPath("~/ViewProduct.aspx", typeof(Page)) as Page; 
             } 
          } 
       } 
    } 
