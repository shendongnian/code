    public class SurveyViewModel {
      public Survey Survey {get; set;}
      public int SurveyId {get; set;}
      public List<Project> Projects {get; set;}
      public List<OrderedItem> OrderedItems {get; set;}
    }
    
    public class OrderedItem {
      public int Id {get; set;}
      public int Order {get; set;}
      public string Category {get; set;}
      public string ItemText {get; set;}
    }
