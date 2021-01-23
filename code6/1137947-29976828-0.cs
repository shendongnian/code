    public class City
    {
        public long ID { get; set; }
        ...
        [NonSerialized, JsonIgnore, ScriptIgnore]
        public State State { get; set; }
        public long StateId
        {
            get { return State.Id; }
            /* Optionally include a set; some JSON serializers may complain in
            absence of it, up to you to experiment with */
            set { State = new State(value); }
        }
        ...
    }
