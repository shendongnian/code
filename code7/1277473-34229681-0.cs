    public class ClientOffer
        {
         public Guid client_id { get; set; }
         [ForeignKey("client_id")]
         public Client client { get; set; }
         public Guid offer_id { get; set; }
         [ForeignKey("offer_id")]
         public Offer offer { get; set; }
        }
