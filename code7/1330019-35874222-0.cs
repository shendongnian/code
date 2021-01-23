        int TotalCount { get; }
    }   
    public class CountList<T> : List<T>, IHasCount
    {
        public int TotalCount { get; set; }
        public CountList(int count)
        {
            TotalCount = count;
        } 
        public CountList(IList<T> list )
        {
            this.AddRange(list);
            this.TotalCount = list.Count;
        }
    }
	
