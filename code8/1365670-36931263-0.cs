    public class AddItemToCartRequest
    {
        public string CartId { get; set; }
        public string ItemId { get; set; }
    }
    public class SomeController : Controller
    {
        [HttpPost]
        public ActionResult AddItem(AddItemToCartRequest request)
        {
            var cart = carts.GetCart(request.CartId);
            var item = items.GetItem(request.ItemId);
           
            cart.AddItem(item);
            carts.Save(cart);
            
            // Redirect to action showing the "item added" or whatever.
        }
    }
