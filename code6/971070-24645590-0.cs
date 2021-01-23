    public class A
    {
        public A(string property0, string property1, string property2)
        {
            Property0 = property0;
            Property1 = property1;
            Property2 = property2;
            SubNodes = new List<A>();
        }
        public string Property0 { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public List<A> SubNodes { get; private set; }
    }
    public class DataSource : List<A>, IRelationList
    {
        IList IRelationList.GetDetailList(int index, int relationIndex)
        {
            return this[index].SubNodes;
        }
        string IRelationList.GetRelationName(int index, int relationIndex)
        {
            return null;
        }
        bool IRelationList.IsMasterRowEmpty(int index, int relationIndex)
        {
            return this[index].SubNodes.Count == 0;
        }
        int IRelationList.RelationCount
        {
            get { return 1; }
        }
    }
