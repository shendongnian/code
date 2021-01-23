    public class InputValue
    {
        public string id{ get; set; }
        public string name{ get; set; }
        [DisplayName("Values")]
        [ValueMember("id")]
        [DisplayMember("name")]
        public IList<IValue> values{ get; set; }
    }
