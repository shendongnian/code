    public class City
    {
        public long ID { get; set; }
        ...
        [JsonIgnore, ScriptIgnore]
        public State State { get; set; }
        public long StateID
        {
            get { return State.ID; }
            /* Optionally include a set; some JSON serializers may complain in
            absence of it, up to you to experiment with */
            set { State = new State(value); }
        }
        ...
    }
