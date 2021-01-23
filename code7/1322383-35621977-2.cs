    public interface IItem
    {
        int id {get;set;}
        string name {get;set;}
        DateTime date {get;set;}
    }
    
    class Source1 : IItem
    {
        public int id {get;set;}
        public  string name {get;set;}
        public  DateTime date {get;set;}
    }
    
    class Destination1 : IItem
    {
        public int id {get;set;}
        public string name {get;set;}
        public DateTime date {get;set;}
    }
