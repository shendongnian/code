    public class SearchParameter<TName, TValues>
    {
        public TName Name { get; set; }
        public List<TValues> { get; set; }
        public SearchParameter(TName name, List<TValues> values)
        {
            Name = name;
            Values = values;
        }
    }
