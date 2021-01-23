    public class foo
    {
        public ListOfBar Bars { get; set; }
    }
    public class bar
    {
        public string foorbar { get; set; }
    }
    [JsonArray(false)]
    public class ListOfBar : List<bar> {}
