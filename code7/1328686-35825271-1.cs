       public bool addShoppingItem(Item item){
               using (var context = new DBContext()) 
               {
                context.items.Add(item);
                context.SaveChanges();
               }
       }
