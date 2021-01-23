    public class Foo
    {
        struct ListWrapper<T>
        {
            public int total { get { return (foos == null ? 0 : foos.Count); } }
            [JsonProperty(DefaultValueHandling=DefaultValueHandling.Ignore)]
            public List<T> foos { get; set; }
            public ListWrapper(List<T> list) : this()
            {
                this.foos = list;
            }
        }
        [JsonProperty("a")]
        public int a;
        [JsonProperty("b")]
        public int b;
        [JsonIgnore]
        public List<Foo> foos;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        ListWrapper<Foo>? moreFoos
        {
            get
            {
                return foos == null ? null : (ListWrapper<Foo>?)new ListWrapper<Foo>(foos);
            }
            set
            {
                foos = (value == null ? null : value.Value.foos);
            }
        }
    }
