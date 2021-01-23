    public class Child
    {
        property Owner Parent { get; set;}
        property int Version { get; set; }   
    }
    class Owner
    {
        public virtual Guid Id { get; protected set; }
        public virtual string NaturalKey { get; protected set; } // never changes
        public virtual Ilist<OwnerData> Data { get; protected set; }
    
        public virtual BData ActualData { get { return Data.Last(); } }
    
        public virtual BData GetActualDataToEdit()
        {
            var newData = ActualData.Clone();
            newData.Version++;
            Data.Add(newData);
            return newData;
        }
    }
    class OwnerData
    {
        public virtual int Version { get; protected set; }
        public OwnerData Clone() { ... }
    }
    // e.g. FluentNHibernate mapping
    mapping.List(x => x.Data, p => p.OrderBy("Version"))
