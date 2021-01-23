    public class AddItemToCartRequest
    {
        public string CartId { get; set; }
        public string ItemId { get; set; }
    }
    public class SomeController : Controller
    {
        // Reference to some sort of repository/data store for shopping carts
        private Carts carts;
        
        // Reference to some sort of repository/data store for store items.
        private Items items;
        public SomeController(Carts carts, Items items)
        {
            this.carts = carts;
            this.items = items;
        }
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
