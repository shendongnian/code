    public class Project
    {
      public int projectId { get; set; }
      public int workspaceId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTime Created { get; set; }
      public virtual ICollection<Card> Cards { get; set; }   
    }
    public class Card
    {
      public int cardId { get; set; }
      public int projectId { get; set; }
      public string Title { get; set; }
      public DateTime Created { get; set; }
      public string Notes { get; set; }          
    }
