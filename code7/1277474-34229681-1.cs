    public class Client
        {
         public Guid Id { get; set; }
         public String RestaurantName { get; set; }
         public ICollection<ClientOffer> offers { get; set; }
        }
