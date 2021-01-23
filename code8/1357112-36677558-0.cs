    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class MustHaveCartItemsAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var cart = ShoppingCart.GetCart(filterContext.HttpContext);
            var ViewBag = filterContext.Controller.ViewBag;
            if (!cart.GetCartItems.Any())
            {
                ViewBag.CartStatus = "Cart is empty please ";
                ViewBag.Link = "Index";
                ViewBag.Link2 = "Store";
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                new { controller = "Cart", action = "Index" }));
            }
        }
    }
