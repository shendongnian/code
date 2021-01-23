     public class Result {
         public string suggestion { get; set; }
         public List<List<int>> matched { get; set; }
         public string format { get; set; } }
     
     public class RootObject {
         public int count { get; set; }
         public List<Result> results { get; set; } }
