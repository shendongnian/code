    public class User
    {
        [Index("UX_User_EmailShopId", 1, IsUnique =  true)]
        public int Id { get; set; }
        [Index("UX_User_EmailShopId", 2, IsUnique = true)]
        public string Email { get; set; }
        [Index("UX_User_EmailShopId", 3, IsUnique = true)]
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }
    }
