     EDentalCADBContext context = new EDentalCADBContext();
      public ActionResult Masters(int? pageNumber, string tableName)
                    {
                        EstablishConnection(); // This creates the connection with DB dynamically.
            
                        
                        int? page = 1;
                        ViewData["MenuItems"] = MenuItem.ActivateMenu("Masters");
                        ViewData["Users"] = context.Users.ToList();
            }
        
         public class EDentalCADBContext : DbContext
            {
               // public EDentalCADBContext() : base("EDentalCADBContext") { }
                public DbSet<NotificationItem> NotificationItems { get; set; }
                public DbSet<User> Users { get; set; }
