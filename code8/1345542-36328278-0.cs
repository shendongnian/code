    public class Course
    {
       public String Name { set; get; }
       public int Code { set; get; }
       // Mapped to column "PreRequire"
       public String PreRequire {
          get {
             return JsonConvert.SerializeObject(PreRequireCources);
          }
          set {
             PreRequireCources = JsonConvert.DeserializeObject<List<string>>(value);
          }
       }
       // Not mapped to any column
       public List<String> PreRequireCources = new List<String>();
    }
