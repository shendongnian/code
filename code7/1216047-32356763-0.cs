    public interface IKnownProperties
    {
       int id {get;}
       int otherParameter { get; }
    }
    // K is key, T is type of content
    class myClass<K, T> where T:IKnownProperties
    {
        private List<T> items;
        private Dictionary<K, T> itemMap;
    } 
    class myConcreteT : IKnownProperties 
    {
        int id {get;set;}
        int otherParameter {get;set;}
    }
       
