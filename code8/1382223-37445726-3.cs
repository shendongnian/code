    public class ShoppingList
    {
        [Key]
        public int Id { get; set; }
        //Other Properties
    }
    public class ShoppingListItem
    {
        [Key]
        public int Id { get; set; }
        //other properties
        public int ShoppingListId { get; set; }
        [ForeignKey("ShoppingListId")]
        public ShoppingList ShoppingList { get; set; }
    }
