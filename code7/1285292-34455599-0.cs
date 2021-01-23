    public class TO2List
    {
         public int A2 { get; set; }
         public string B2 { get; set; }
         public string C2 { get; set; }
    }
    public class DO
    {
         public int A { get; set; }
         public string B { get; set; }
         public string C { get; set; }
         public List<TO2List> TO2_List { get; set; }
    }
    public class RootObject
    {
        public DO DO { get; set; }
    }
