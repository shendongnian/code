       public bool addShoppingItem(Item item){
               using (var context = new DBContext()) 
               {
                context.items.Add(item);
                context.SaveChanges();
               }
       }
 
      public bool addShoppingItem(ShoppingList sl){
                using (var context = new DBContext()) 
                {
                 context.shoppingLists.Add(sl);
                 context.SaveChanges();
                }
        }
