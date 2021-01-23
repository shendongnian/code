    public class SearchParameter<T>
    {
        public T Name { get; set; }
        public List<T> Values { get; set; }
        public SearchParameter(T name, List<T> values)
        {
            Name = name;
            Values = values;
        }
    }
