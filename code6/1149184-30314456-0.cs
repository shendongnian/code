    public class CustomADataRetrieverImpl<T, C>: IDataRetriever<T, C> 
                 where T : ICollection<string>, new()
    {
        public T GetData(C criteria)
        {
            string myCriteria = criteria.ToString();
            T data = new T()
                ...
            return data;
        }
    }
