    public class C
    {
        [Newtonsoft.Json.JsonConverter(typeof(BCJsonConverter))]
        public ObservableCollection<A> As
        {
            get;
            set;
        }
    }
