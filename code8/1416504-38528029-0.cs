    public class Question
    {
      public string Id { get; set; } = Guid.NewGuid().ToString();
      public List<Variant> Variants { get; set; }
    
      public string CorrectVariantId { get; set; }
      public Variant CorrectVariant { get; set; }
    }
     
    public class Variant
    {
      public string Id { get; set; } = Guid.NewGuid().ToString();
     
      public string QuestionId { get; set; }
      public Question Question { get; set; }
      
      public Question SecondQuestion { get; set; }
    }
