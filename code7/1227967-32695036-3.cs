    public class C
    {
        public virtual ObservableCollection<A> As
        {
            get;
            set;
        }
    }
    public class D : C
    {
        [Newtonsoft.Json.JsonConverter(typeof(BCJsonConverter))]
        public override ObservableCollection<A> As
        {
            get;
            set;
        }
    }
