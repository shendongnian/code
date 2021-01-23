    public class ShopUser 
    {
        public string LoginID { get; set; }
        public string SessionID { get; set; }
        public long UserId { get; set; }
        public long ShoppingCartId { get; set; }
        public bool? Status
       {
           get{ return SessionHelper. myShopUser;}
           set{ SessionHelper. myShopUser = value; }
       }
    }
