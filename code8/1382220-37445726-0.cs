    public class ShoppingList
    {
        [Key]
        public int Id { get; set; }
        public int ShoppingListItemId { get; set; }
        [ForeignKey("ShoppingListItemId")]
        public ShoppingListItem ShoppingListItem { get; set; }
    }
    public class ShoppingListItem
    {
        [Key]
        public int Id { get; set; }
        //other properties
    }
