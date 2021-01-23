    public class CriteriaDetail : ICriteriaDetail
    {
        public CriteriaDetail(string title, int numberOfEvents, IEnumerable<ICriteriaDetail> childCriteria)
        {
            Title = title;
            NumberOfEvents = numberOfEvents;
            ChildCriteria = childCriteria;
        }
    
        public string Title { get; set; }
        public int NumberOfEvents { get; set; }
        public IEnumerable<ICriteriaDetail> ChildCriteria { get; set; }
    }
