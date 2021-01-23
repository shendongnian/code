    [DataContract]
    public class DataContractList<T> : IList<T>
    {
        [DataMember]
        protected readonly IList<T> InnerList;
    
        public DataContractList()
        {
            InnerList = new List<T>();
        }
    
        public DataContractList(IList<T> items)
        {
            InnerList = items;
        }
    }
