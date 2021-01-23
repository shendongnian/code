    public class MyData{
      [JsonProperty("success")]
      public bool Success {get;set;}
    
      public Dictionary<string,Course> Courses{get; private set;}
      
      public MyData(){
        Courses = new Dictionary<string, Course>();
      } 
    }
