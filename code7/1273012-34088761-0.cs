    public class ListTwo
    {
       public string name { get; set; }
    }
    public class ListOne
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<ListTwo> listTwo { get; set; }
    }
    public class RootObject
    {
        public string name { get; set; }
        public List<ListOne> listOne { get; set; }
    }
