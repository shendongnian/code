    public class Client 
    {
      public Guid ClientId { get; set; }
      public string FirstName { get; set; }
    
      public virtual ICollection<ClientCard> ClientCard { get; set; }
    }
    public class Card
    {
      public Guid CardId { get; set; }
      public string Number { get; set; }
    
      public virtual ICollection<ClientCard> ClientCard { get; set; }
    }
    public class ClientCard
    {
      public Guid ClientCardId { get; set; }
      public Guid CardId { get; set; }
      public Guid ClientId { get; set; }
    
      public virtual Client Client { get; set; }
      public virtual Card Card { get; set; }
    }
